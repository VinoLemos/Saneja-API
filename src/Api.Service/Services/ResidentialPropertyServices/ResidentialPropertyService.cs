using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.ResidencialPropertyServices;
using Domain.Repository;

namespace Api.Service.Services.ResidencialPropertyServices
{
    public class ResidentialPropertyService : IResidentialPropertyService
    {
        private readonly IResidentialPropertyRepository _repository;

        public ResidentialPropertyService(IResidentialPropertyRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<ResidentialProperty> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<ResidentialProperty> GetByRgi(int? rgi)
        {
            return await _repository.FindByRgi(rgi);
        }

        public async Task<IEnumerable<ResidentialProperty>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<IEnumerable<ResidentialProperty>> GetByStreet(string? street)
        {
            return await _repository.FindByStreet(street);
        }

        public async Task<ResidentialProperty> Post(ResidentialProperty residentialProperty)
        {
            return await _repository.InsertAsync(residentialProperty);
        }

        public async Task<ResidentialProperty> Put(ResidentialProperty residentialProperty)
        {
            return await _repository.UpdateAsync(residentialProperty);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}