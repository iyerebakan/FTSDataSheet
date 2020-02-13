using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public int DataSheetId { get; set; }
        public int UserId { get; set; }        
        public string CommentText { get; set; }
        public int? CommentId { get; set; }
        public DateTime CreateDate { get; set; }

        [InverseProperty("Comments")]
        public virtual DataSheet DataSheet { get; set; }

        [InverseProperty("Comments")]
        public virtual User User { get; set; }
    }
}
