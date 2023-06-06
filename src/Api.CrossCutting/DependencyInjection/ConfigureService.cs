using Api.Data.Context;
using Api.Domain.Entities;
using Api.Service.Services.ResidencialPropertyServices;
using Api.Service.Services.TechnicalVisitServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Service.Services.AgentServices;
using Service.Services.PersonServices;
using Service.Services.TokenServices;
using System.Reflection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
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

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<UserTokenService>();

            services.AddScoped<PersonService>();
            services.AddScoped<AgentService>();
            services.AddScoped<ResidentialPropertyService>();
            services.AddScoped<TechnicalVisitService>();
        }
    }
}
