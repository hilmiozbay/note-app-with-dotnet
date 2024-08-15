using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje5.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Notes> Notes { get; set; }
        public bool IsAdmin { get; internal set; }
    }

}

