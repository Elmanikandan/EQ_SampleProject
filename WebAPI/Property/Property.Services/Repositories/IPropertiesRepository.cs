using Property.Services.Models;

namespace Property.Services.Repositories
{
    public interface IPropertiesRepository
    {
        IEnumerable<Properties> GetAllProperty();
        Properties GetPropertyById(int id);
        Properties AddProperty(Properties property);
        Properties UpdateProperty(Properties property);
        void DeleteProperty(int id);
    }
}
