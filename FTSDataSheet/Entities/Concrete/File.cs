using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class File : IEntity
    {
        public int Id { get; set; }
        public int DataSheetId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ContentType { get; set; }
        public string Uploader { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateUser { get; set; }

        [InverseProperty("Files")]
        public virtual DataSheet DataSheet { get; set; }

        [InverseProperty("Files")]
        [ForeignKey("CreateUser")]
        public virtual User User { get; set; }
    }
}
