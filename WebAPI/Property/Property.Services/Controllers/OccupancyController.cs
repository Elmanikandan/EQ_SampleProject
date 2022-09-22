using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupancyController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public OccupancyController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Occupancy> GetOccupancy()
        {
            return _unitOfWork.Occupancy.GetAll().ToList();
        }
    }
}
