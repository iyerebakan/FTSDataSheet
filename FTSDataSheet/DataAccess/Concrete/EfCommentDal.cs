using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Expressions;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfCommentDal : EfEntityRepositoryBase<Comment, FTSDataSheetContext>, ICommentDal
    {
        public List<CommentDto> GetCommentDtos(int dataSheetId)
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.Comments.Where(k => k.DataSheetId == dataSheetId).Select(CommentExpression.CommentDto).ToList();
            }
        }

        public List<CommentDto> GetPreviousCommentDtos(int commentId)
        {
            using (var context = new FTSDataSheetContext())
            {
                return context.Comments.Where(k => k.Id == commentId || k.CommentId == commentId)
                    .Select(CommentExpression.CommentDto).ToList();
            }
        }
    }
}
