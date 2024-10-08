﻿using System;
using EntityFrameworkApp.Implementations;
using EntityFrameworkApp.Interfaces;
using EntityFrameworkApp.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EntityFrameworkApp.Data
{
    public static class ServiceProviderFactory
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static ServiceProviderFactory()
        {
            var services = new ServiceCollection();
            services.AddScoped<DataContext>();
            services.AddScoped<IStudent, StudentImplement>();
            services.AddScoped<IAddress, AddressImplement>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
