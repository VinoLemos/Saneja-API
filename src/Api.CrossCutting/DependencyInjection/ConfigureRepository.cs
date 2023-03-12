using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Interfaces;
using Api.Domain.Repository;
using Data.Implementations;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services, string? mySqlConnection, string? migrationAssembly)
        {
            services.AddDbContext<MyContext>(options =>
                options.UseMySql(mySqlConnection,
                    ServerVersion.AutoDetect(mySqlConnection),
                    b => b.MigrationsAssembly(migrationAssembly)));

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IPersonRepository, PersonImplementation>();
            services.AddScoped<IAgentRepository, AgentImplementation>();
            services.AddScoped<IResidentialPropertyRepository, ResidentialPropertyImplementation>();
        }
    }
}