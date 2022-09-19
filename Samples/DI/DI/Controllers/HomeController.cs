using DI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _repository = null;
  
        public HomeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public JsonResult Index()
        {
            List<Employee> allEmployeeDetails = _repository.GetAllEmployees();
            return Json(allEmployeeDetails);
        }
        public JsonResult GetStudentDetails(int Id)
        {
            Employee employeeDetails = _repository.GetEmployeeById(Id);
            return Json(employeeDetails);
        }
    }
}
