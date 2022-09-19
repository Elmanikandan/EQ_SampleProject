using System.Collections.Generic;
using System.Linq;

namespace DI.Models
{
    public class EmployeeRepository : IEmployeeRepository   
    {
        public List<Employee> DataSource()
        {
            return new List<Employee>()
            {
                new Employee() { EmpId = 101, EmpName = "James", Department = "IT", Unit = "1", Gender = "Male" },
                new Employee() { EmpId = 102, EmpName = "Smith", Department = "Operations", Unit = "2", Gender = "Male" },
                new Employee() { EmpId = 103, EmpName = "David", Department = "Finance", Unit = "2", Gender = "Male" },
                new Employee() { EmpId = 104, EmpName = "Sara", Department = "IT", Unit = "1", Gender = "Female" },
                new Employee() { EmpId = 105, EmpName = "Pam", Department = "Operations", Unit = "2", Gender = "Female" }
            };
        }
        public Employee GetEmployeeById(int EmpId)
        {
            return DataSource().FirstOrDefault(e => e.EmpId == EmpId);
        }
        public List<Employee> GetAllEmployees()
        {
            return DataSource();
        }
    }
}
