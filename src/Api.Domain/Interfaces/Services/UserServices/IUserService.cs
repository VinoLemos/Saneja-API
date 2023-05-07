using Api.Domain.Entities;
using Domain.Dtos.User;

namespace Api.Domain.Interfaces.Services.PersonServices
{
    public interface IUserService
    {
        Task<User> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Post(UserCreateDto person);
        Task<User> Put(UserUpdateDto person);
        Task<bool> Delete(Guid id);
    }
}