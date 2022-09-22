using System.ComponentModel.DataAnnotations;

namespace Property.Services.Models
{
    public class Occupancy
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public string OccupiedBy { get; set; }
        public DateTime OccupiedOn { get; set; }
        
    }
}
