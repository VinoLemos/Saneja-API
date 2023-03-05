using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services;
using Api.Domain.Interfaces.Services.PersonServices;
using Api.Domain.Repository;

namespace Api.Service.Services.PersonServices
{
    public class PersonLoginService : ILoginService<Person>
    {
        private IPersonRepository _repository;

        public PersonLoginService(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Person> FindByLogin(Person user)
        {
            var basePerson = new Person();
            
            basePerson = await _repository.FindByLogin(user.Email);

            return basePerson ?? throw new SystemException("Usuário não encontrado");
        }
    }
}