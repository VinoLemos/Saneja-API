using Api.Domain.Entities;
using AutoMapper;
using Data.Repository;
using Domain.Dtos.User;

namespace Service.Services.PersonServices
{
    public class PersonService
    {
        private readonly PersonRepository _repository;
        private readonly IMapper _mapper;

        public PersonService(PersonRepository repository, IMapper mapper)
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

        public async Task<bool> UserExists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }
    }
}
