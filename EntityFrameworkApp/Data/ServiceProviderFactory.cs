using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkApp.Implementations;
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
            services.AddScoped<IStudent, StudentRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
