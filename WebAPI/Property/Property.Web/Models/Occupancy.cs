namespace Property.Web.Models
{
    public class Occupancy
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public string OccupiedBy { get; set; }
        public DateTime OccupiedOn { get; set; }
    }
}
