using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.PersonServices;
using Domain.Dtos.User;

namespace Domain.Interfaces.Services.PersonServices
{
    public class IPersonService : IUserService
    {
        public Task<User> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Post(UserCreateDto person)
        {
            throw new NotImplementedException();
        }

        public Task<User> Put(UserUpdateDto person)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
