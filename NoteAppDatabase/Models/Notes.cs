using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje5.Models
{
    public class Notes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime LastUpdateTime { get; set; }

        public virtual Account Account { get; set; }
    }
}

