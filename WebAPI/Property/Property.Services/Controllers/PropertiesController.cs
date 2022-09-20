using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public PropertiesController(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Properties> GetProperties()
        {
            return _unitOfWork.Properties.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Properties GetPropertyById(int id)
        {
            return _unitOfWork.Properties.GetFirstOrDefault(x=>x.Id==id);
        }

        [HttpPost]
        public Properties Create([FromBody] Properties registration)
        {
            _unitOfWork.Properties.Add(registration);
            _unitOfWork.Save();
            return registration;
        }

        [HttpPut]
        public Properties Update([FromForm] Properties registration)
        {
            _unitOfWork.Properties.Update(registration);
            _unitOfWork.Save();
            return registration;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var obj = _unitOfWork.Properties.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Properties.Remove(obj);
            _unitOfWork.Save();
        }
    }
}
