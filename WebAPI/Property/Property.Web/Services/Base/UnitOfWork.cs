using Microsoft.Extensions.Options;
using Property.Web.Models;

namespace Property.Web.Services.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IOptions<ApiUrls> apiUrls)
        {
            RegistrationService = new RegistrationHttpservice(apiUrls);
            PropertiesService = new PropertyHttpservice(apiUrls);
            OccupancyService = new OccupancyHttpservice(apiUrls);
        }
        public IApiService<RegistrationModel> RegistrationService { get; private set; }
        public IApiService<Properties> PropertiesService { get; private set; }
        public IApiService<Occupancy> OccupancyService { get; private set; }

    }
}
