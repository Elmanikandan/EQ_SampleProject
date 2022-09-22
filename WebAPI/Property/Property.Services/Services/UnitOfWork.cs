using Property.Services.Data;
using Property.Services.Repositories;

namespace Property.Services.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _db;

        public UnitOfWork(AppDbContext db) 
        {
            _db = db;
            Registration = new RegistrationRepository(_db);
            Properties = new PropertiesRepository(_db);
            Occupancy = new  OccupancyRepository(_db);
        }

        public IRegistrationRepository Registration { get; private set; }
        public IPropertiesRepository Properties { get; private set; }
        public IOccupancyRepository Occupancy { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
