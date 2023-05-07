using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : UserRepository<User>
    {
        private DbSet<User> _dataset;

        public UserImplementation(MyContext context) : base(context)
        {
            _dataset = context.Set<User>();
        }

        public async Task<User> FindByLogin(string email)
        {
            return await _dataset.FirstOrDefaultAsync( p => p.Email.Equals(email)) 
            ??
            throw new SystemException("Usuário não encontrado");
        }

        public async Task<User> UpdateAgentAsync(User item)
        {
            try
            {
                var result = await _dataset.SingleOrDefaultAsync(x => x.Id == item.Id);

                if (result == null) return null;

                result.UserName = item.UserName ?? result.UserName;               
                result.Email = item.Email ?? result.Email;
                result.PhoneNumber = item.PhoneNumber ?? result.PhoneNumber;

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