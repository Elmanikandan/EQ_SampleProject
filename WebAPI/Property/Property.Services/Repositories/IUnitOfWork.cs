﻿namespace Property.Services.Repositories
{
    public interface IUnitOfWork
    {
        IRegistrationRepository Registration { get; }
        IPropertiesRepository Properties { get; }

        void Save();
    }
}
