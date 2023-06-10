using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class ResidentialPropertyRepository : IBaseRepository<ResidentialProperty>
    {
        private readonly MyContext _context;

        public ResidentialPropertyRepository(MyContext context)
        {
            _context = context;
        }
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResidentialProperty> InsertAsync(ResidentialProperty item, Guid id)
        {
            item.PersonId = id;
            await _context.ResidencialProperties.AddAsync(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<ResidentialProperty> SelectAsync(Guid id)
        {
            var property = await _context.ResidencialProperties.FirstOrDefaultAsync(r => id.Equals(r.Id));

            return property ?? throw new ArgumentException("Imóvel não encontrado");
        }

        public async Task<ResidentialProperty> SelectByRgi(int rgi)
        {
            var property = await _context.ResidencialProperties.FirstOrDefaultAsync(r => r.Rgi.Equals(rgi));

            return property ?? throw new ArgumentException("Imóvel não encontrado");
        }

        public async Task<List<ResidentialProperty>> SelectUserProperties(Guid userId)
        {
            var properties = await _context.ResidencialProperties.Where(r => r.PersonId.Equals(userId)).ToListAsync();

            if (properties.Count == 0) return null;

            return properties;
        }

        public Task<IEnumerable<ResidentialProperty>> SelectAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(ResidentialProperty item)
        {
            try
            {
                var currentProperty = await _context.ResidencialProperties.FirstOrDefaultAsync(r => r.Id.Equals(item.Id));

                if (currentProperty == null) throw new ArgumentException("Imóvel não encontrado");

                currentProperty.Hidrometer = item.Hidrometer;
                currentProperty.Cep = item.Cep;
                currentProperty.Street = item.Street;
                currentProperty.Number = item.Number;
                currentProperty.Neighborhood = item.Neighborhood;
                currentProperty.City = item.City;
                currentProperty.Complement = item.Complement;
                currentProperty.CreatedAt = DateTime.Now;

                _context.ResidencialProperties.Update(currentProperty);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<ResidentialProperty> InsertAsync(ResidentialProperty item)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<ResidentialProperty>.UpdateAsync(ResidentialProperty item)
        {
            throw new NotImplementedException();
        }
    }
}
