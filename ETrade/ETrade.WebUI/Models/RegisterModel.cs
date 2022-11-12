using System.ComponentModel.DataAnnotations;

namespace ETrade.WebUI.Models
{
    public class RegisterModel
    {
        [Required]
        public string FullName { get; set; } 
        [Required]
        public string UserName { get; set; } 
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email;
    }
}
