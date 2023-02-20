using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.AgentServices;

namespace Api.Service.Services.AgentServices
{
    public class AgentService : IAgentServices
    {
        private readonly IRepository<Agent> _repository;

        public AgentService(IRepository<Agent> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<Agent> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Agent>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Agent> Post(Agent agent)
        {
            return await _repository.InsertAsync(agent);
        }

        public async Task<Agent> Put(Agent agent)
        {
            return await _repository.UpdateAsync(agent);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}