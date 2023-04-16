using Api.Data.Implementations;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.AgentServices;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Models;

namespace Api.Service.Services.AgentServices
{
    public class AgentService : IAgentService
    {
        private readonly AgentImplementation _repository;
        private readonly IMapper _mapper;

        public AgentService(AgentImplementation repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var agent = await _repository.SelectAsync(id);
            
            return _mapper.Map<UserDto>(agent);
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var agents = await _repository.SelectAsync();

            return _mapper.Map<List<UserDto>>(agents);
        }

        public async Task<UserCreateResultDto> Post(UserCreateDto agent)
        {
            var model = _mapper.Map<UserModel>(agent);
            var entity = _mapper.Map<Agent>(model);
            var result = await _repository.InsertAsync(entity);

            return _mapper.Map<UserCreateResultDto>(result);
        }

        public async Task<UserUpdateResultDto> Put(UserUpdateDto agent)
        {
            var model = _mapper.Map<UserModel>(agent);
            var entity = _mapper.Map<Agent>(model);
            var result = await _repository.UpdateAgentAsync(entity);

            return _mapper.Map<UserUpdateResultDto>(result);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}