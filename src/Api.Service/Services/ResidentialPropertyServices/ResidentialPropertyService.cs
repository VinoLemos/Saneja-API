using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.PersonServices;
using Api.Domain.Interfaces.Services.ResidencialPropertyServices;

namespace Api.Service.Services.ResidencialPropertyServices
{
    public class ResidentialPropertyService : IResidentialPropertyService
    {
        private readonly IRepository<ResidentialProperty> _repository;

        public ResidentialPropertyService(IRepository<ResidentialProperty> repository)
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

        public async Task<IEnumerable<ResidentialProperty>> GetAll()
        {
            return await _repository.SelectAsync();
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