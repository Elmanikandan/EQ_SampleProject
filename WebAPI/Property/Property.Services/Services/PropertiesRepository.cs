using Property.Services.Data;
using Property.Services.Models;
using Property.Services.Repositories;

namespace Property.Services.Services
{
    public class PropertiesRepository : IPropertiesRepository
    {
        private readonly AppDbContext _db;

        public PropertiesRepository(AppDbContext db)
        {
            _db = db;
        }

        public Properties AddProperty(Properties property)
        {
            _db.Properties.Add(property);
            _db.SaveChanges();
            return property;
        }

        public void DeleteProperty(int id)
        {
            var obj =_db.Properties.Find(id);
            _db.Properties.Remove(obj);
            _db.SaveChanges();
        }

        public IEnumerable<Properties> GetAllProperty()
        {
            return _db.Properties.ToList();
        }

        public Properties GetPropertyById(int id)
        {
            return _db.Properties.Find(id);
        }      

        public Properties UpdateProperty(Properties property)
        {
            _db.Properties.Update(property);
            _db.SaveChanges();
            return property;
        }
    }
}
