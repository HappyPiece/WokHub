using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WokHub.DTO
{
    public class LoginDTO
    {
        [DisplayName("email"), Required]
        public string? Email { get; set; }

        [DisplayName("password"), Required]
        public string? Password { get; set; }
    }
}
