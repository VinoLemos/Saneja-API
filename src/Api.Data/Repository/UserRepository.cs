using Api.Data.Context;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repository
{
    public class UserRepository : IBaseRepository<User>
    {
        protected readonly MyContext _context;
        public UserRepository(MyContext context)
        {
            _context = context;
        }

        public async Task<User> SelectAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id) ?? throw new ArgumentException("Usuário não encontrado");
        }

        public async Task<IEnumerable<User>> SelectAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id) != null;
        }


        public void UpdateAsync(User user)
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Id == user.Id) ?? throw new ArgumentException("Usuário não encontrado");

            currentUser = user;

            _context.Users.Update(currentUser);
            _context.SaveChangesAsync();
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<User> IBaseRepository<User>.InsertAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}