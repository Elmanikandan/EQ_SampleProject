using Microsoft.AspNetCore.Mvc.Rendering;
using Property.Web.Models;

namespace Property.Web.ViewModels
{
    public class RegistrationViewModel
    {
        public RegistrationModel Registration { get; set; } = new RegistrationModel();
        public List<SelectListItem> CustomerType { get; } = new List<SelectListItem>
    {
        new SelectListItem { Value = "Customer", Text = "Customer" },
        new SelectListItem { Value = "Owner", Text = "Owner" }
    };
    }
}
