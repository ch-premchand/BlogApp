using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogLab.Models.Account
{
    public class ApplicationUserLogin
    {
        [Required(ErrorMessage="Username is required")]
        [MinLength(5,ErrorMessage ="must be at least 5-20 characters")]
        [MaxLength(20,ErrorMessage ="must be at least 5-20 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "password  is required")]
        [MinLength(10, ErrorMessage = "must be at least 10-50 characters")]
        [MaxLength(50, ErrorMessage = "must be at least 10-50 characters")]
        public string password { get; set; }
    }
}
