using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IAgentRepository
    {
        Task<Agent> FindByLogin(string email);
    }
}