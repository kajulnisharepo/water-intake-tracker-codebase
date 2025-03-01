using System.ComponentModel.DataAnnotations;

namespace WaterIntakeTracker.Models
{
    public class RegistrationResponseModel
    {
        [Required]
        public string Message { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public double BMI { get; set; }
    }
}
