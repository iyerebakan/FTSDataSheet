using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int? CommentId { get; set; }
        public int DataSheetId { get; set; }
        public string RoleName { get; set; }
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public string CommentText { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
    }
}
