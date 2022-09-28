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
    public class ResultService : ICustomService<Result>
    {
        private readonly IRepository<Result> _resultRepository; public ResultService(IRepository<Result> resultRepository)
        {
            _resultRepository = resultRepository;
        }
        public void Delete(Result entity)
        {
            try
            {
                if (entity != null)
                {
                    _resultRepository.Delete(entity);
                    _resultRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Result Get(int Id)
        {
            try
            {
                var obj = _resultRepository.Get(Id);
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
        public IEnumerable<Result> GetAll()
        {
            try
            {
                var obj = _resultRepository.GetAll();
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
        public void Insert(Result entity)
        {
            try
            {
                if (entity != null)
                {
                    _resultRepository.Insert(entity);
                    _resultRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(Result entity)
        {
            try
            {
                if (entity != null)
                {
                    _resultRepository.Remove(entity);
                    _resultRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(Result entity)
        {
            try
            {
                if (entity != null)
                {
                    _resultRepository.Update(entity);
                    _resultRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}