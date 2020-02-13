using Business.Abstract;
using Business.Providers;
using Core.Utilities.Extensions;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dto;
using MailSync;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IEmailProvider _emailProvider;
        private readonly IDataSheetService _dataSheetService;
        private readonly IUserService _userService;
        public CommentManager(ICommentDal commentDal, IEmailProvider emailProvider, 
            IDataSheetService dataSheetService,IUserService userService)
        {
            _commentDal = commentDal;
            _emailProvider = emailProvider;
            _dataSheetService = dataSheetService;
            _userService = userService;
        }
        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
            try
            {
                _emailProvider.Subject = "YKK Data Sheet Bildirimi Hk.";
                _emailProvider.toAddress = GetToAddress(comment);
                _emailProvider.Content = GetContent(comment);
                _emailProvider.SendMail();
            }
            catch 
            {

            }
        }

        public void Delete(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public List<CommentDto> GetCommentsByDataSheetId(int datasheetId)
        {
            return _commentDal.GetCommentDtos(datasheetId);
        }

        public List<CommentDto> GetPreviousComments(int commentId)
        {
            return _commentDal.GetPreviousCommentDtos(commentId);
        }

        private List<EmailAddress> GetToAddress(Comment comment)
        {
            var ftsuser = _dataSheetService.GetById(comment.DataSheetId).FTSUserId;
            if (ftsuser == null)
                return null;

            List<EmailAddress> emailAddresses = new List<EmailAddress>();
            emailAddresses.Add(new EmailAddress
            {
                Address = _userService.GetById((int)ftsuser).Email
            });
            emailAddresses.Add(new EmailAddress
            {
                Address = _userService.GetById(comment.UserId).Email
            });

            return emailAddresses;
        }

        private string GetContent(Comment comment)
        {
            var user = _userService.GetById(comment.UserId);
            string content = "";
            if(user.RoleId != 1)
            {
                content = "YKK Çalışanı: <b>" + user.Email + " yorum yaptı. " + comment.CreateDate.DateStringWithTime() + "</b>";
            }
            else
            {
                content = "Müşteri: <b>" + user.Email + " yorum yaptı. " + comment.CreateDate.DateStringWithTime() + "<b>";
            }
            content = content + "<br>" + comment.CommentText;
            if (comment.CommentId > 0)
            {
                var previouses = GetPreviousComments((int)comment.CommentId).OrderByDescending(k => k.CreateDate).ToList();
                foreach (var comm in previouses)
                {
                    if (comm.RoleName != "Customer")
                    {
                        content = "<br><br><br>YKK Çalışanı: " + comm.Email + " yorum yaptı. " + comm.CreateDate.DateStringWithTime();
                    }
                    else
                    {
                        content = "<br><br><br>Müşteri: " + comm.Email + " yorum yaptı. " + comm.CreateDate.DateStringWithTime();
                    }
                    content = content + "<br>" + comm.CommentText;
                }
            }

            return content;
        }
    }
}
