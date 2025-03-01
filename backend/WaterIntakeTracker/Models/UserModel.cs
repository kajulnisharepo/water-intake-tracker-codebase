using System.ComponentModel.DataAnnotations;

namespace WaterIntakeTracker.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(1, 500, ErrorMessage = "Weight must be between 1 and 500 kg")]
        public double Weight { get; set; } // in kilograms

        [Required(ErrorMessage = "Height is required")]
        [Range(1, 300, ErrorMessage = "Height must be between 1 and 300 cm")]
        public double Height { get; set; } // in centimeters
    }
}
