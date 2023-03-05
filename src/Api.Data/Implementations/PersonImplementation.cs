using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class PersonImplementation : BaseRepository<Person>, IPersonRepository
    {
        private DbSet<Person> _dataset;

        public PersonImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<Person>();
        }

        public async Task<Person> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync( p => p.Email.Equals(email)) 
            ??
            throw new SystemException("Usuário não encontrado");
        }
    }
}