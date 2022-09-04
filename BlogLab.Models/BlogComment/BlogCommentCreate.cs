using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BlogLab.Models.BlogComment
{
    public class BlogCommentCreate
    {
        public int BlogCommentId { get; set; }

        public int? ParentBlogCommentId { get; set; }

        public int BlogId { get; set; }

        [Required(ErrorMessage = "content is required")]
        [MinLength(10, ErrorMessage = "must be atleast 10-300characters")]
        [MaxLength(300, ErrorMessage = "must be at least 10-300 characters")]
        public string Content { get; set; }
    }
}
