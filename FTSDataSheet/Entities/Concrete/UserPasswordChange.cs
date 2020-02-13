using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class UserPasswordChange : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string OldPassword { get; set; }

        [InverseProperty("UserPasswordChanges")]
        public virtual User User { get; set; }
    }
}
