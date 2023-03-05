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
    public class AgentImplementation : BaseRepository<Agent>, IAgentRepository
    {
        private DbSet<Agent> _dataset;

        public AgentImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<Agent>();
        }

        public async Task<Agent> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync( p => p.Email.Equals(email)) 
            ??
            throw new SystemException("Usuário não encontrado");
        }
    }
}