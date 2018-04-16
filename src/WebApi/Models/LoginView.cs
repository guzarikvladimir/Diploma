using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class LoginView
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}