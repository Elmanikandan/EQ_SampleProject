using System.ComponentModel.DataAnnotations;

namespace Property.Services.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
