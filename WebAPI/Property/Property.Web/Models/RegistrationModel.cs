using System.ComponentModel.DataAnnotations;

namespace Property.Web.Models
{
    public class RegistrationModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [RegularExpression(@"^[0-9]{10}$")]
        public string MobileNumber { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
    }
}
