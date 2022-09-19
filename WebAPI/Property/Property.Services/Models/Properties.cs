using System.ComponentModel.DataAnnotations;

namespace Property.Services.Models
{
    public class Properties
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PropertyNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public Decimal CostPerSqft { get; set; }
        [Required]
        public Decimal NumberOfSqft { get; set; }
        public Decimal TotalCost { get; set; }
    }
}
