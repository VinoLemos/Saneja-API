using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.PersonServices
{
    public interface IPersonService
    {
        Task<Person> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<Person>> GetAll();
        Task<Person> Post(Person person);
        Task<Person> Put(Person person);
        Task<bool> Delete(Guid id);
    }
}