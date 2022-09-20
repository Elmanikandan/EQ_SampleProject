using Property.Services.Models;

namespace Property.Services.Repositories
{
    public interface IRegistrationRepository
    {
        IEnumerable<Registration> GetAllUser();
        Registration GetUserById(int id);
        Registration AddUser(Registration user);
        Registration UpdateUser(Registration user);
        void DeleteUser(int id);
    }
}
