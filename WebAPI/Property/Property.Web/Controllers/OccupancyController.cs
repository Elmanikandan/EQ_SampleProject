using Microsoft.AspNetCore.Mvc;
using Property.Web.Services.Base;

namespace Property.Web.Controllers
{
    public class OccupancyController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public OccupancyController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            var result = await unitOfWork.OccupancyService.GetAllAsync();
            return View(result.Record);
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var response = await unitOfWork.OccupancyService.GetAllAsync();
            return Json(new { data = response.Record });
        }
    }
}
