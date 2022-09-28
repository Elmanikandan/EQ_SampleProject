using StudentRegistration.Domain.Data;
using StudentRegistration.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        #region property         
        private readonly StudentContext _applicationDbContext;         
        private DbSet<T> entities;         
        #endregion          
        #region Constructor         
        public Repository(StudentContext applicationDbContext)         
        {             
            _applicationDbContext = applicationDbContext;             
            entities = _applicationDbContext.Set<T>();        
        }         
        #endregion
        public void Delete(T entity)
        {
            if (entity == null)
            { 
                throw new ArgumentNullException("Entity"); 
            }
            entities.Remove(entity); 
            _applicationDbContext.SaveChanges();
        }

        public T Get(int Id)
        {
            return entities.SingleOrDefault(c => c.Id == Id);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public void Insert(T entity)
        {
            if(entity == null)             
            { 
                throw new ArgumentNullException("Entity"); 
            }
            entities.Add(entity); 
            _applicationDbContext.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entity");
            }
            entities.Remove(entity);
            _applicationDbContext.SaveChanges();
        }

        public void SaveChanges()
        {
            _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null) 
            { 
                throw new ArgumentNullException("Entity"); 
            }
            entities.Update(entity); 
            _applicationDbContext.SaveChanges();
        }
    }
}
