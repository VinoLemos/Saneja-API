using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public async Task<Agent> UpdateAgentAsync(Agent item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == item.Id);

                if (result == null) return null;

                result.Name = item.Name ?? result.Name;               
                result.Email = item.Email ?? result.Email;
                result.Phone = item.Phone ?? result.Phone;

                _context.Entry(result).CurrentValues.SetValues(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}