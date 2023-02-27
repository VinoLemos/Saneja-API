using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.TechnicalVisitServices
{
    public interface ITechnicalVisitService
    {
        Task<TechnicalVisit> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<TechnicalVisit>> GetAll();
        Task<TechnicalVisit> Post(TechnicalVisit technicalVisit);
        Task<TechnicalVisit> Put(TechnicalVisit technicalVisit);
        Task<bool> Delete(Guid id);
    }
}