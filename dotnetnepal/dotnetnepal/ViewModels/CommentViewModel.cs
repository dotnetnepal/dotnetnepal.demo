using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetnepal.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "You have exceeded the maximum length of 100 characters")]
        public string AuthorName { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "You have exceeded the maximum length of 1000 characters")]
        public string Body { get; set; }
    }
}
