using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class AgentRepository : IBaseRepository<User>
    {
        private readonly MyContext _context;

        public AgentRepository(MyContext context)
        {
            _context = context;
        }

        public Task<User> InsertAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SelectAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Agent"
                              select u).FirstOrDefaultAsync();

            return user ?? throw new ArgumentException("Usuário não encontrado");
        }

        public async Task<IEnumerable<User>> SelectAsync()
        {
            var users = await (from u in _context.Users
                               join ur in _context.UserRoles on u.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where r.Name == "Agent"
                               select u).ToListAsync();

            return users;
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Agent"
                              select u).FirstOrDefaultAsync();

            return user != null;
        }


        public void UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Agent"
                              select u).FirstOrDefaultAsync();

            if (user == null) throw new ArgumentException("Usuário não encontrado");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}