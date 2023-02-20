using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.TechnicalVisitServices;

namespace Api.Service.Services.TechnicalVisitServices
{
    public class TechnicalVisitService : ITechnicalVisitServices
    {
        private readonly IRepository<TechnicalVisit> _repository;

        public TechnicalVisitService(IRepository<TechnicalVisit> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _repository.ExistsAsync(id);
        }

        public async Task<TechnicalVisit> Get(Guid id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<TechnicalVisit>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<TechnicalVisit> Post(TechnicalVisit technicalVisit)
        {
            return await _repository.InsertAsync(technicalVisit);
        }

        public async Task<TechnicalVisit> Put(TechnicalVisit technicalVisit)
        {
            return await _repository.UpdateAsync(technicalVisit);
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}