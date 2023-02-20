using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.PersonServices;

namespace Api.Service.Services.PersonServices
{
    public class PersonService : IPersonService
    {

        private readonly IRepository<Person> _repository;

        public PersonService(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<Person> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<Person> Post(Person person)
        {
            return await _repository.InsertAsync(person);
        }

        public async Task<Person> Put(Person person)
        {
            return await _repository.UpdateAsync(person);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}