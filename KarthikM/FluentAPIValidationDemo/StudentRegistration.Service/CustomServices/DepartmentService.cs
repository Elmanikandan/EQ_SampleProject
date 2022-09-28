using StudentRegistration.Domain.Models;
using Repository.IRepository;
using StudentRegistration.Service.ICustomServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Service.CustomServices
{
    public class DepartmentService : ICustomService<Department>
    {
        private readonly IRepository<Department> _departmenttRepository; 
        public DepartmentService(IRepository<Department> departmenttRepository)
        {
            _departmenttRepository = departmenttRepository;
        }
        public void Delete(Department entity)
        {
            try
            {
                if (entity != null)
                {
                    _departmenttRepository.Delete(entity);
                    _departmenttRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Department Get(int Id)
        {
            try
            {
                var obj = _departmenttRepository.Get(Id);
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IEnumerable<Department> GetAll()
        {
            try
            {
                var obj = _departmenttRepository.GetAll();
                if (obj != null)
                {
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Insert(Department entity)
        {
            try
            {
                if (entity != null)
                {
                    _departmenttRepository.Insert(entity);
                    _departmenttRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Department entity)
        {
            try
            {
                if (entity != null)
                {
                    _departmenttRepository.Remove(entity);
                    _departmenttRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Department entity)
        {
            try
            {
                if (entity != null)
                {
                    _departmenttRepository.Update(entity);
                    _departmenttRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

}
