using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PersonRepository : IBaseRepository<User>
    {
        private readonly MyContext _context;

        public PersonRepository(MyContext context)
        {
            _context = context;
        }
        public async Task<bool> InsertAsync(User item)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = item.Email,
                Name = item.Name,
                Email = item.Email,
                EmailConfirmed = false,
                Birthday = item.Birthday,
                Rg = item.Rg,
                Cpf = item.Cpf,
                PhoneNumber = item.PhoneNumber
            };

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<User> SelectAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Person"
                              select u).FirstOrDefaultAsync();

            return user ?? throw new ArgumentException("Usuário não encontrado");
        }

        public async Task<User> SelectUserAsync(Guid id)
        {
            var user = await (from u in _context.Users
                          where u.Id == id
                          select u).FirstOrDefaultAsync();

            return user ?? throw new ArgumentException("Usuário não encontrado");
        }

        public async Task<IEnumerable<User>> SelectAsync()
        {
            var users = await (from u in _context.Users
                               join ur in _context.UserRoles on u.Id equals ur.UserId
                               join r in _context.Roles on ur.RoleId equals r.Id
                               where r.Name == "Person"
                               select u).ToListAsync();

            return users;
        }
        public async Task<bool> ExistsAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Person"
                              select u).FirstOrDefaultAsync();

            return user != null;
        }
        public async void UpdateAsync(User item)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == item.Id) ?? throw new ArgumentException("Usuário não encontrado");

            user.Name = item.Name ?? user.Name;
            user.Email = item.Email ?? user.Email;
            user.PhoneNumber = item.PhoneNumber ?? user.PhoneNumber;
            user.Birthday = item.Birthday ?? user.Birthday;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var user = await (from u in _context.Users
                              join ur in _context.UserRoles on u.Id equals ur.UserId
                              join r in _context.Roles on ur.RoleId equals r.Id
                              where u.Id == id && r.Name == "Person"
                              select u).FirstOrDefaultAsync();

            if (user == null) throw new ArgumentException("Usuário não encontrado");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
