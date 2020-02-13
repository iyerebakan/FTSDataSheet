using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class UserRole : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        //[InverseProperty("UserRoles")]
        //public virtual User User { get; set; }

        //[InverseProperty("UserRoles")]
        //public virtual Role Role { get; set; }
    }
}
