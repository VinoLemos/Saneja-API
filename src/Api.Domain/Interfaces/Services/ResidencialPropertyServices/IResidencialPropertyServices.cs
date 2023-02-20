using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.ResidencialPropertyServices
{
    public interface IResidencialPropertyServices
    {
        Task<ResidencialProperty> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<ResidencialProperty>> GetAll();
        Task<ResidencialProperty> Post(ResidencialProperty residencialProperty);
        Task<ResidencialProperty> Put(ResidencialProperty residencialProperty);
        Task<bool> Delete(Guid id);
    }
}