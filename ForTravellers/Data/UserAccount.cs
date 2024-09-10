using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ForTravellers.Data
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(UserName), IsUnique = true)]
    public class UserAccount
    {

        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 characters")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [MaxLength(50, ErrorMessage = "Should be less than 50 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email Name is required")]
        [MaxLength(100, ErrorMessage = "Should be less than 100 characters")]
        // [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name is required")]
        [MaxLength(20, ErrorMessage = "Should be less than 20 characters")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [MaxLength(20, ErrorMessage = "Should be less than 20 characters")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
   
 
