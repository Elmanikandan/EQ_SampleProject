using Property.Services.Data;
using Property.Services.Models;
using Property.Services.Repositories;
using System.Linq.Expressions;

namespace Property.Services.Services
{
    public class RegistrationRepository : Repository<Registration>,  IRegistrationRepository
    {
        private readonly AppDbContext _db;

        public RegistrationRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }    


        public void Update(Registration user)
        {
            _db.Registration.Update(user);
        }

    }
}
