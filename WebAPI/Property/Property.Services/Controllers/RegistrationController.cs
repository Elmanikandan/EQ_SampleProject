
using Microsoft.AspNetCore.Mvc;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
           
            _registrationRepository = registrationRepository;
        }

        [HttpGet]
        public IEnumerable<Registration> GetUser()
        {
            return _registrationRepository.GetAllUser().ToList();
        }

        [HttpGet("{id}")]
        public Registration GetUserById(int id)
        {
            return _registrationRepository.GetUserById(id);
        }

        [HttpPost]
        public Registration Create([FromBody] Registration registration)
        {
            return _registrationRepository.AddUser(registration);
        }

        [HttpPut]
        public Registration Update([FromForm] Registration registration)
        {
            return _registrationRepository.UpdateUser(registration);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _registrationRepository.DeleteUser(id);
        }
    }
}
