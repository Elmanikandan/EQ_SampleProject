using Microsoft.AspNetCore.Mvc;
using Property.Web.Services.Base;
using Property.Web.ViewModels;

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
            List<OccupancyVM> occ = new List<OccupancyVM>();
            foreach(var res in response.Record)
            {
                OccupancyVM occup = new OccupancyVM();
                occup.CustomerName = await GetNameById(res.CustomerId);
                occup.OwnerName = await GetNameById(res.OwnerId);
                occup.PropertyNumber = (await unitOfWork.PropertiesService.GetAsync(res.PropertyId)).Record.PropertyNumber;
                occup.OccupiedOn = res.OccupiedOn;
                occ.Add(occup);
            }

            return Json(new { data = occ });
        }
        
        private async Task<string> GetNameById(int id)
        {
            var result = await unitOfWork.RegistrationService.GetAsync(id);
            return result.Record.Name;
        }
    }
}
