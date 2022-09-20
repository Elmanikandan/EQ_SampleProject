using Property.Services.Data;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Services
{
    public class PropertiesRepository : Repository<Properties>, IPropertiesRepository
    {
        private readonly AppDbContext _db;

        public PropertiesRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Properties user)
        {
            _db.Properties.Update(user);
        }
    }
}
