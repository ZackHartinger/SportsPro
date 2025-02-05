using System.ComponentModel.DataAnnotations;

namespace SportsPro.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required(ErrorMessage = "Please enter a name.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter an email.")]
        public string Email { get; set; } = string.Empty;

        [Phone]
        [Required(ErrorMessage = "Please enter a phone number.")]
        public string PhoneNumber { get; set; } = string.Empty;



    }
}
