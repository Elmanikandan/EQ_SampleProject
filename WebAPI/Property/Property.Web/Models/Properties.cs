using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Property.Web.Models
{
    public class Properties
    {        
        public int Id { get; set; }
        [DisplayName("Property Number")]
        public string PropertyNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        [DisplayName("Cost Per Sq.ft")]
        public Decimal CostPerSqft { get; set; }
        [DisplayName("No. Of Sq.ft")]
        public Decimal NumberOfSqft { get; set; }
        [DisplayName("Total Cost")]
        public Decimal TotalCost { get; set; }
    }
}
