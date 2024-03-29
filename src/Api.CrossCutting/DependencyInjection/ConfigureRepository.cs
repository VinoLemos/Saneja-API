using Api.Data.Context;
using Data.Repository;
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

            services.AddScoped(typeof(PersonRepository));
            services.AddScoped(typeof(AgentRepository));
            services.AddScoped(typeof(ResidentialPropertyRepository));
            services.AddScoped(typeof(TechnicalVisitRepository));
        }
    }
}