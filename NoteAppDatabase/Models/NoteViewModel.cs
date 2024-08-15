using System;
using System.ComponentModel.DataAnnotations;

namespace Proje5.Models
{
    public class NoteViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
    }

}

