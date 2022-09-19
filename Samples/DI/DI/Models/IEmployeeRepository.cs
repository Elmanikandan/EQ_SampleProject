using System.Collections.Generic;

namespace DI.Models
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int StudentId);
        List<Employee> GetAllEmployees();
    }
}
