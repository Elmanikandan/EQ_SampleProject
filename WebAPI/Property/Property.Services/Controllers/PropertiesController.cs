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
        private IPropertiesRepository _propertiesRepository;

        public PropertiesController(IPropertiesRepository propertiesRepository)
        {

            _propertiesRepository = propertiesRepository;
        }

        [HttpGet]
        public IEnumerable<Properties> GetProperties()
        {
            return _propertiesRepository.GetAllProperty().ToList();
        }

        [HttpGet("{id}")]
        public Properties GetPropertyById(int id)
        {
            return _propertiesRepository.GetPropertyById(id);
        }

        [HttpPost]
        public Properties Create([FromBody] Properties registration)
        {
            return _propertiesRepository.AddProperty(registration);
        }

        [HttpPut]
        public Properties Update([FromForm] Properties registration)
        {
            return _propertiesRepository.UpdateProperty(registration);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _propertiesRepository.DeleteProperty(id);
        }
    }
}
