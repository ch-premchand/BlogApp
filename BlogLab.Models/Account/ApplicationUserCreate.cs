using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLab.Models.Account
{
    class ApplicationUserCreate : ApplicationUserLogin
    {
        [MinLength(10, ErrorMessage = "must be at least 10-30 characters")]
        [MaxLength(30, ErrorMessage = "must be at least 10-30 characters")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "email is required")]
        [EmailAddress(ErrorMessage ="invalis mail")]
        [MaxLength(30, ErrorMessage = "must be at least 5-20 characters")]
        public string  Email { get; set; }
    }
}
