using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WokHub.DAL.Models;

namespace WokHub.DTO
{
    public class RegisterDTO
    {
        [DisplayName("email"), Required]
        public string? Email { get; set; }

        [DisplayName("password"), Required]
        public string? Password { get; set; }

        [DisplayName("fullName"), Required]
        public string? FullName { get; set; }

        [DisplayName("address")]
        public string? Address { get; set; }

        [DisplayName("birthDate")]
        public string? BirthDate { get; set; }
       
        [DisplayName("phoneNumber")]
        public string? PhoneNumber { get; set; }
        
        [DisplayName("gender"), Required]
        public Gender? Gender { get; set; }
    }
}
