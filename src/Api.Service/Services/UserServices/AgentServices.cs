using Api.Data.Implementations;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.PersonServices;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Models;
using System;

namespace Api.Service.Services.PersonServices
{
    public class AgentServices : IUserService
    {
        private readonly UserImplementation _repository;
        private readonly IMapper _mapper;

        public AgentServices(UserImplementation repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<User> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<User> Post(UserCreateDto person)
        {
            var entity = MapCreateDtoToEntity(person);
            var result = await _repository.InsertAsync(entity);

            return await _repository.InsertAsync(result);
        }

        public async Task<User> Put(UserUpdateDto person)
        {
            var entity = MapUpdateDtoToEntity(person);
            var result = await _repository.InsertAsync(entity);

            return await _repository.UpdateAsync(result);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        private User MapCreateDtoToEntity(UserCreateDto dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            return _mapper.Map<User>(model);
        }
        private User MapUpdateDtoToEntity(UserUpdateDto dto)
        {
            var model = _mapper.Map<UserModel>(dto);
            return _mapper.Map<User>(model);
        }
    }
}