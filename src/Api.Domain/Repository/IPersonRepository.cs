using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Api.Domain.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> FindByLogin (string email);
    }
}