using Entities.Concrete;
using Entities.Dto;
using MailSync;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICommentService
    {
        List<CommentDto> GetCommentsByDataSheetId(int datasheetId);
        List<CommentDto> GetPreviousComments(int commentId);
        void Add(Comment comment);
        void Delete(Comment comment);
    }
}
