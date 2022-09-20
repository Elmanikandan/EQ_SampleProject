using Property.Services.Models;

namespace Property.Services.Repositories
{
    public interface IRegistrationRepository : IRepository<Registration>
    {
        void Update(Registration user);
    }
}
