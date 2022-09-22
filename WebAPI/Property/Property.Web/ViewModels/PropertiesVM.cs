using Microsoft.AspNetCore.Mvc.Rendering;
using Property.Web.Models;

namespace Property.Web.ViewModels
{
    public class PropertiesVM
    {
        public Properties Properties { get; set; } = new Properties();
        public List<SelectListItem> Type { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Rent", Text = "Rent" },
            new SelectListItem { Value = "Own", Text = "Own" }
        };
        public List<SelectListItem> Status { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Available", Text = "Available" },
            new SelectListItem { Value = "Sold", Text = "Sold" }
        };

        public List<SelectListItem> Owner { get; set; }
    }
}
