using System.ComponentModel.DataAnnotations;

namespace ForTravellers.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Services cannot be longer than 50 characters")]
        public string Services { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Image cannot be longer than 50 characters")]
        public string Image { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Description cannot be longer than 100 characters")]
        public string Description { get; set; }
    }
}
