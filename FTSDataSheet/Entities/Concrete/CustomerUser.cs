using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Concrete
{
    public class CustomerUser : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

    }
}
