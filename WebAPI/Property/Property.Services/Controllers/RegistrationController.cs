
using Microsoft.AspNetCore.Mvc;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
           
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<Registration> GetUser()
        {
            return _unitOfWork.Registration.GetAll().ToList();
        }

        [HttpGet("{id}")]
        public Registration GetUserById(int id)
        {
            return _unitOfWork.Registration.GetFirstOrDefault(u=>u.Id==id);
        }

        [HttpPost]
        public Registration Create([FromBody] Registration registration)
        {
            _unitOfWork.Registration.Add(registration);
            _unitOfWork.Save();
            return registration;
        }

        [HttpPut]
        public async Task<Registration> Edit([FromBody] Registration registration)
        {
            _unitOfWork.Registration.Update(registration);
            _unitOfWork.Save();
            return registration;
        }

        [HttpDelete("{id}")]
        public Registration Delete(int id)
        {
            var obj = _unitOfWork.Registration.GetFirstOrDefault(u=>u.Id == id);
            _unitOfWork.Registration.Remove(obj);
            _unitOfWork.Save();
            return obj;
        }
    }
}
