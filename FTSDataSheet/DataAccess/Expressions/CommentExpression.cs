using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Expressions
{
    public static class CommentExpression
    {
        public static Expression<Func<Comment, CommentDto>> CommentDto
        {
            get
            {
                return c => new CommentDto()
                {
                    Id = c.Id,
                    CommentId = c.CommentId,
                    CreateDate = c.CreateDate,
                    CommentText = c.CommentText,
                    DataSheetId = c.DataSheetId,
                    UserName = c.User.FirstName + " " + c.User.LastName,
                    Logo = c.User.RoleId == 1 ? "user.jpg" : "ftsuser.jpg",
                    Email = c.User.Email,
                    RoleName = c.User.Role.Name
                };
            }
        }
    }
}
