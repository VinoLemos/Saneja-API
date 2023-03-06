using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementations
{
    public class ResidentialPropertyImplementation : BaseRepository<ResidentialProperty>, IResidentialPropertyRepository
    {
        private DbSet<ResidentialProperty> _dataSet;

        public ResidentialPropertyImplementation(MyContext context) : base(context)
        {
            _dataSet = context.Set<ResidentialProperty>();
        }

        public async Task<ResidentialProperty> FindByRgi(int? rgi)
        {
            return await _dataSet.FirstOrDefaultAsync(r => r.Rgi == rgi)
            ??
            throw new SystemException("RGI não encontrado");
        }

        public async Task<IEnumerable<ResidentialProperty>> FindByStreet(string? street)
        {
            return await _dataSet.Where(r => r.Street == street).ToListAsync()
            ??
            throw new SystemException("Não foram encontrados imóveis na rua informada");
        }
    }
}
