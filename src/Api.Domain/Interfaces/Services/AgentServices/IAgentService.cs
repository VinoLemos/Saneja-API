using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.AgentServices
{
    public interface IAgentService
    {
        Task<Agent> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<Agent>> GetAll();
        Task<Agent> Post(Agent agent);
        Task<Agent> Put(Agent agent);
        Task<bool> Delete(Guid id);
    }
}