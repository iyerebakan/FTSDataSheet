using Core.DataAccess;
using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
        List<CommentDto> GetCommentDtos(int dataSheetId);
        List<CommentDto> GetPreviousCommentDtos(int commentId);
    }
}
