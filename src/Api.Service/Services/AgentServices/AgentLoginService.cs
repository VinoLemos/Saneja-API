using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Repository;

namespace Api.Service.Services.AgentServices
{
    public class AgentLoginService : ILoginService<Agent>
    {
        private readonly IAgentRepository _repository;

        public AgentLoginService(IAgentRepository repository)
        {
            _repository = repository;
        }
        public async Task<object> FindByLogin(LoginDto login)
        {
            var baseAgent = new Agent();
            
            baseAgent = await _repository.FindByLogin(login.Email);

            return baseAgent ?? throw new SystemException("Usuário não encontrado");
        }
    }
}