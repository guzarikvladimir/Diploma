using System.ComponentModel.DataAnnotations;

namespace CP.Authorization.Contract.Models
{
    public class LoginView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}