using System.ComponentModel.DataAnnotations;

namespace ForTravellers.Models
{
    public class Reservation
    {
        [Key]
        public int RegistrationId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Email cannot be longer than 50 characters")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot be longer than 50 characters")]
        public string Offers { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot be longer than 50 characters")]
        public string Service { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "PhoneNumber cannot be longer than 15 characters")]
        public string PhoneNo { get; set; }
        [Required]
        [MaxLength(15, ErrorMessage = "Cannot be longer than 15 characters")]
        public string NIC { get; set; }
    }
}
