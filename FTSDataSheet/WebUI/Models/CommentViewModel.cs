using Entities.Concrete;
using Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class CommentViewModel
    {
        public List<CommentDto> Comments { get; set; }
        public List<CommentDto> ReplyComments { get; set; }
        public string Message { get; set; }
    }

}
