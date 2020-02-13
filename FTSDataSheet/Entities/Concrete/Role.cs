using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [InverseProperty("Role")]
        public virtual ICollection<User> Users { get; set; }
    }
}
