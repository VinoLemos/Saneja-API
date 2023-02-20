using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.AgentServices
{
    public interface IAgentServices
    {
        Task<Agent> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<Agent>> GetAll();
        Task<Agent> Post(Agent agent);
        Task<Agent> Put(Agent agent);
        Task<bool> Delete(Guid id);
    }
}