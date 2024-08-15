using System;
using System.ComponentModel.DataAnnotations;

namespace Proje5.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
