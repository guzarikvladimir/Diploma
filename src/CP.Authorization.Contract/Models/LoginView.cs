using System.ComponentModel.DataAnnotations;

namespace CP.Authorization.Contract.Models
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