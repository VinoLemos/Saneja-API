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
    public class ResidencialPropertyService : IResidencialPropertyServices
    {
        private readonly IRepository<ResidencialProperty> _repository;

        public ResidencialPropertyService(IRepository<ResidencialProperty> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<ResidencialProperty> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ResidencialProperty>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ResidencialProperty> Post(ResidencialProperty residencialProperty)
        {
            return await _repository.InsertAsync(residencialProperty);
        }

        public async Task<ResidencialProperty> Put(ResidencialProperty residencialProperty)
        {
            return await _repository.UpdateAsync(residencialProperty);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}