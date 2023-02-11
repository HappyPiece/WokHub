using System.ComponentModel;

namespace WokHub.DAL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public string? BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public Gender? Gender { get; set; }

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiryTime { get; set; }
    }

    public enum Gender {
       Male = 0,
       Fermale = 1
    }
}
