using Microsoft.AspNetCore.Mvc;
using StudentRegistration.Domain.Data;
using StudentRegistration.Domain.Models;
using StudentRegistration.Service.ICustomServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentRegistration.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ICustomService<Student> _customService;
        private readonly StudentContext _applicationDbContext;
        public StudentController(ICustomService<Student> customService, StudentContext applicationDbContext)
        {
            _customService = customService;
            _applicationDbContext = applicationDbContext;
        }
        [HttpGet(nameof(GetStudentById))]
        public IActionResult GetStudentById(int Id)
        {
            var obj = _customService.Get(Id);
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpGet(nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {
            var obj = _customService.GetAll();
            if (obj == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost(nameof(CreateStudent))]
        public IActionResult CreateStudent(Student student)
        {
            if (student != null)
            {
                _customService.Insert(student);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Somethingwent wrong");
            }
        }
        [HttpPost(nameof(UpdateStudent))]
        public IActionResult UpdateStudent(Student student)
        {
            if (student != null)
            {
                _customService.Update(student);
                return Ok("Updated SuccessFully");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete(nameof(DeleteStudent))]
        public IActionResult DeleteStudent(Student student)
        {
            if (student != null)
            {
                _customService.Delete(student);
                return Ok("Deleted Successfully");
            }
            else
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
