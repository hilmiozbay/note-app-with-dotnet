using System;
using System.ComponentModel.DataAnnotations;

namespace Proje5.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string MailAddress { get; set; }

        public bool IsActive { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public virtual Account Account { get; set; }
    }
}

