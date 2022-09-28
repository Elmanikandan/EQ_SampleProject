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
    public class SubjectGpaService : ICustomService<SubjectGpa>
    {
        private readonly IRepository<SubjectGpa> _subjectRepository; 
        public SubjectGpaService(IRepository<SubjectGpa> subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public void Delete(SubjectGpa entity)
        {
            try
            {
                if (entity != null)
                {
                    _subjectRepository.Delete(entity);
                    _subjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public SubjectGpa Get(int Id)
        {
            try
            {
                var obj = _subjectRepository.Get(Id);
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
        public IEnumerable<SubjectGpa> GetAll()
        {
            try
            {
                var obj = _subjectRepository.GetAll();
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
        public void Insert(SubjectGpa entity)
        {
            try
            {
                if (entity != null)
                {
                    _subjectRepository.Insert(entity);
                    _subjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Remove(SubjectGpa entity)
        {
            try
            {
                if (entity != null)
                {
                    _subjectRepository.Remove(entity);
                    _subjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Update(SubjectGpa entity)
        {
            try
            {
                if (entity != null)
                {
                    _subjectRepository.Update(entity);
                    _subjectRepository.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}