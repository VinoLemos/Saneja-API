using Api.Domain.Entities;
using AutoMapper;
using Data.Repository;
using Domain.Dtos.User;

namespace Service.Services.AgentServices
{
    public class AgentService
    {
        private readonly AgentRepository _repository;
        private readonly IMapper _mapper;

        public AgentService(AgentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> ListUsersAsync()
        {
            var users = await _repository.SelectAsync();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> SelectUserAsync(Guid id)
        {
            var user = await _repository.SelectAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDetailsDto> ReadUserDetails(Guid id)
        {
            var user = await _repository.SelectAsync(id);

            return _mapper.Map<UserDetailsDto>(user);
        }

        public async Task<bool> UserExists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public bool UpdateUser(UserUpdateDto user)
        {
            try
            {
                var currentUser = _mapper.Map<User>(user);

                _repository.UpdateAsync(currentUser);

                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
