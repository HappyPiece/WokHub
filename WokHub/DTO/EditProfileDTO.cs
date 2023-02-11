using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WokHub.DAL.Models
{
    public class EditProfileDTO
    {
        [DisplayName("fullName"), Required]
        public string? FullName { get; set; }

        [DisplayName("address")]
        public string? Address { get; set; }

        [DisplayName("birthDate")]
        public string? birthDate { get; set; }

        [DisplayName("phoneNumber")]
        public string? PhoneNumber { get; set; }

        [DisplayName("gender"), Required]
        public Gender? Gender { get; set; }
    }
}
