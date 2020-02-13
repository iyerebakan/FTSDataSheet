using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public int? CustomerId { get; set; }
        public int? RoleId { get; set; }

        [InverseProperty("Users")]
        public virtual Role Role { get; set; }

        [InverseProperty("Users")]
        public virtual Customer Customer { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<File> Files { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<DataSheet> DataSheet { get; set; }

        [InverseProperty("FTSUser")]
        public virtual ICollection<DataSheet> FTSDataSheet { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<UserPasswordChange> UserPasswordChanges { get; set; }
    }
}
