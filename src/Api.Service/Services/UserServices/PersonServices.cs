using Api.Data.Implementations;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.PersonServices;
using AutoMapper;
using Domain.Dtos.User;
using Domain.Models;

namespace Api.Service.Services.PersonServices
{
    public class PersonServices : IUserService
    {
        private readonly UserImplementation _repository;
        private readonly IMapper _mapper;

        public PersonServices(UserImplementation repository, IMapper mapper)
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

        public async Task<User> Post(UserCreateDto user)
        {
            var entity = MapCreateDtoToEntity(user);

            return await _repository.InsertAsync(entity);
        }

        public async Task<User> Put(UserUpdateDto user)
        {
            var entity = MapUpdateDtoToEntity(user);

            return await _repository.UpdateAsync(entity);
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