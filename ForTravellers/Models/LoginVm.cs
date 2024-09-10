using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;

namespace ForTravellers.Models
{
    [Keyless]
    public class LoginVm
    {
       
            [Required(ErrorMessage = "User Name or Email is required")]
            [MaxLength(50, ErrorMessage = "Should be less than 50 characters")]
            [DisplayName("User Name or Email")]
            public string UserNameOrEmail { get; set; }

            [Required(ErrorMessage = "Password is required")]
            [StringLength(20, MinimumLength = 5, ErrorMessage = "Should be less than 20 characters and more than 5 characters")]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        
    }
}
