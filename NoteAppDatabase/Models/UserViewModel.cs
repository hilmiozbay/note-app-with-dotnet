using System.ComponentModel.DataAnnotations;

namespace Proje5.Models
{
    public class UserViewModel
    {
        public int Id { get; set; } 
        public string Firstname { get; set; }       
        public string Surname { get; set; }
        public string MailAddress { get; set; }
    }
}
