using System.ComponentModel.DataAnnotations;

namespace ForTravellers.Models
{
    public class Pkg
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Cannot be longer than 50 characters")]
        public string? Offer { get; set; }
        public string? Image { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string? Description { get; set; }
    }
}
