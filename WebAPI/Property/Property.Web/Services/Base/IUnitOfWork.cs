﻿using Property.Web.Models;

namespace Property.Web.Services.Base
{
    public interface IUnitOfWork
    {
        IApiService<RegistrationModel> RegistrationService { get; }
    }
}
