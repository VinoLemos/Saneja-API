using Domain.Dtos.User;

namespace Api.Domain.Interfaces.Services.AgentServices
{
    public interface IAgentService
    {
        Task<UserDto> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserCreateResultDto> Post(UserCreateDto agent);
        Task<UserUpdateResultDto> Put(UserUpdateDto agent);
        Task<bool> Delete(Guid id);
    }
}