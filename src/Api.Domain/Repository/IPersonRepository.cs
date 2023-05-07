using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IPersonRepository
    {
        Task<User> FindByLogin (string email);
    }
}