using DbRepository.Interfaces;
using DbRepository.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Services.Implementations;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdkTabber.AppStart
{
    public static class DIBuilder
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ITabService, TabService>();
        }

        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<ITabRepository, TabRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
        }
    }
}
