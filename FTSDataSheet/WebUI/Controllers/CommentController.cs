using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using MailSync;
using Microsoft.AspNetCore.Mvc;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IDataSheetService _dataSheetService;
        public CommentController(ICommentService commentService,IDataSheetService dataSheetService)
        {
            _commentService = commentService;
            _dataSheetService = dataSheetService;
        }

        [HttpPost]
        public JsonResult AddComment([FromBody]Comment comment)
        {
            CommentViewModel model = new CommentViewModel(); 
            try
            {
                comment.UserId = Convert.ToInt32(UserIdentityInfo.Id);
                comment.CreateDate = DateTime.Now;
                _commentService.Add(comment);
                var comments = _commentService.GetCommentsByDataSheetId(comment.DataSheetId);
                model.Comments = comments.Where(k => k.CommentId == null).OrderByDescending(k => k.CreateDate).ToList();
                model.ReplyComments = comments.Where(k => k.CommentId != null).OrderByDescending(k => k.CreateDate).ToList();
                model.Message = "";
                if (UserIdentityInfo.Roles.Contains(Roles.FTSUser))
                {
                    var datasheet = _dataSheetService.GetById(comment.DataSheetId);
                    datasheet.FTSUserId = Convert.ToInt32(UserIdentityInfo.Id);
                    _dataSheetService.Update(datasheet);
                }
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult GetComments(int Id)
        {
            CommentViewModel model = new CommentViewModel();
            try
            {
                var comments = _commentService.GetCommentsByDataSheetId(Id);
                model.Comments = comments.Where(k => k.CommentId == null).OrderByDescending(k => k.CreateDate).ToList();
                model.ReplyComments = comments.Where(k => k.CommentId != null).OrderByDescending(k => k.CreateDate).ToList();
                model.Message = "";
            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }
            return Json(model);
        }
    }
}