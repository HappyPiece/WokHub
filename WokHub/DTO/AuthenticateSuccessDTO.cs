using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WokHub.DTO
{
    public class AuthenticateSuccessDTO
    {
        [DisplayName("accessToken"), Required]
        public string? AccessToken { get; set; }
        
        [DisplayName("refreshToken"), Required]
        public string? RefreshToken { get; set; }
    }
}
