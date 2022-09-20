using Microsoft.AspNetCore.Mvc;
using Property.Web.Services.Base;

namespace Property.Web.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public RegistrationController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var result = await unitOfWork.RegistrationService.GetAllAsync();
            return View(result.Record);
        }
    }
}
