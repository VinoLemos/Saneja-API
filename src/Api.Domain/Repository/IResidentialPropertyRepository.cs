using Api.Domain.Entities;
using Api.Domain.Interfaces;

namespace Domain.Repository
{
    public interface IResidentialPropertyRepository : IRepository<ResidentialProperty>
    {
        Task<ResidentialProperty> FindByRgi(int? rg);
        Task<IEnumerable<ResidentialProperty>> FindByStreet(string? street);
    }
}
