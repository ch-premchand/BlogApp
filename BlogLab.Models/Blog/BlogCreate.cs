using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLab.Models.Blog
{
    class BlogCreate
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MinLength(10, ErrorMessage = "must be atleast 10-50 characters")]
        [MaxLength(50, ErrorMessage = "must be at least 10-50 characters")]

        public string Title { get; set; }

        [Required(ErrorMessage = "content is required")]
        [MinLength(300,ErrorMessage = "must be atleast 300-3000characters")]
        [MaxLength(3000, ErrorMessage = "must be at least 300-3000 characters")]
        public string Content { get; set; }

        public int? PhotoId { get; set; }
    }
}
