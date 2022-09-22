using Property.Services.Data;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Services
{
    public class OccupancyRepository : Repository<Occupancy>, IOccupancyRepository
    {
        private readonly AppDbContext _db;

        public OccupancyRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
