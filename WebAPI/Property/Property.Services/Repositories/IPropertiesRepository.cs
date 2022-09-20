using Property.Services.Models;

namespace Property.Services.Repositories
{
    public interface IPropertiesRepository : IRepository<Properties>
    {       
        void Update(Properties user);
    }
}
