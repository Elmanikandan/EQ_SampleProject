namespace Property.Web.Models
{
    public class Properties
    {        
        public int Id { get; set; }
        public string PropertyNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string Owner { get; set; }
        public Decimal CostPerSqft { get; set; }
        public Decimal NumberOfSqft { get; set; }
        public Decimal? TotalCost { get; set; }
    }
}
