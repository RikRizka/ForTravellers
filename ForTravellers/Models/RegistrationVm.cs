using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ForTravellers.Models
{
    [Keyless]
    public class RegistrationVm
    {

        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Name is required")]
        [MaxLength(100, ErrorMessage = "Should be less than 100 characters")]
        [RegularExpression(@"^([\w\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "PLeasse enter a valid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(20, ErrorMessage = "Should be less than 20 characters")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Should be less than 20 characters and more than 5 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
