using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class UserForChangePassword : IDto
    {
        public int Id { get; set; }
        public string NewPassword { get; set; }
        public string NewPasswordAgain { get; set; }
        public string Email { get; set; }
    }
}
