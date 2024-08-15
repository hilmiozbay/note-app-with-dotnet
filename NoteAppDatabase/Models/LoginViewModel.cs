using System;
using System.ComponentModel.DataAnnotations;

    namespace Proje5.Models
    {
        public class LoginViewModel
        {

            [Required]    
            public string Username { get; set; } 

            [Required]
            public string Password { get; set; }
        }
    }



