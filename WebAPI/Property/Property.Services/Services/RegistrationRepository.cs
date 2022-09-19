using Property.Services.Data;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Services
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly AppDbContext _db;

        public RegistrationRepository(AppDbContext db)
        {
            _db = db;
        }

        public Registration AddUser(Registration user)
        {
            _db.Registration.Add(user);
            _db.SaveChanges();
            return user;
        }

        public void DeleteUser(int id)
        {
            var obj = _db.Registration.Find(id);           
            _db.Registration.Remove(obj);
            _db.SaveChanges();
        }

        public IEnumerable<Registration> GetAllUser()
        {
            return _db.Registration.ToList();
        }

        public Registration GetUserById(int id)
        {
            return _db.Registration.Find(id);
        }

        public Registration UpdateUser(Registration user)
        {
            _db.Registration.Update(user);
            _db.SaveChanges();
            return user;
        }
    }
}
