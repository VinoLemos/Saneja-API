using Api.Data.Context;
using Api.Data.Implementations;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.PersonServices;
using Api.Domain.Interfaces.Services.ResidencialPropertyServices;
using Api.Domain.Interfaces.Services.TechnicalVisitServices;
using Api.Service.Services.PersonServices;
using Api.Service.Services.ResidencialPropertyServices;
using Api.Service.Services.TechnicalVisitServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.TokenServices;
using System.Reflection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
            // User Services
            services.AddTransient<IUserService, PersonServices>();

            // Technical Visit Services
            services.AddTransient<ITechnicalVisitService, TechnicalVisitService>();

            // Residential Property Services
            services.AddTransient<IResidentialPropertyService, ResidentialPropertyService>();

            services.AddTransient<UserImplementation>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<UserTokenService>();

            // Identity Services
            // Identity Services
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<MyContext>()
                .AddDefaultTokenProviders()
                .AddRoleManager<RoleManager<IdentityRole<Guid>>>()
                .AddUserManager<UserManager<User>>()
                .AddSignInManager<SignInManager<User>>()
                .AddDefaultUI();

            services.AddScoped<IUserStore<User>, UserStore<User, IdentityRole<Guid>, MyContext, Guid>>();
            services.AddScoped<IRoleStore<IdentityRole<Guid>>, RoleStore<IdentityRole<Guid>, MyContext, Guid>>();


            // Roles

            // Other services and repositories
            // ...
        }
    }
}
