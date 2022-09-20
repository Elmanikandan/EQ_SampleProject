using Microsoft.Extensions.Options;
using Property.Web.Models;

namespace Property.Web.Services.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IOptions<ApiUrls> apiUrls)
        {
            RegistrationService = new RegistrationHttpservice(apiUrls);
        }
        public IApiService<RegistrationModel> RegistrationService { get; private set; }

    }
}
