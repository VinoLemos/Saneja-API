using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.AgentServices;
using Api.Domain.Interfaces.Services.PersonServices;
using Api.Domain.Interfaces.Services.ResidencialPropertyServices;
using Api.Domain.Interfaces.Services.TechnicalVisitServices;
using Api.Service.Services.AgentServices;
using Api.Service.Services.PersonServices;
using Api.Service.Services.ResidencialPropertyServices;
using Api.Service.Services.TechnicalVisitServices;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<ILoginService<Person>, PersonLoginService>();

            services.AddTransient<IAgentService, AgentService>();
            services.AddTransient<ILoginService<Agent>, AgentLoginService>();

            services.AddTransient<ITechnicalVisitService, TechnicalVisitService>();

            services.AddTransient<IResidentialPropertyService, ResidentialPropertyService>();
        }
    }
}