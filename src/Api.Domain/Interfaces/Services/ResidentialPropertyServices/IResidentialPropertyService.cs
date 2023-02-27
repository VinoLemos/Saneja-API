using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.ResidencialPropertyServices
{
    public interface IResidentialPropertyService
    {
        Task<ResidentialProperty> Get(Guid id);
        Task<bool> Exists(Guid id);
        Task<IEnumerable<ResidentialProperty>> GetAll();
        Task<ResidentialProperty> Post(ResidentialProperty residencialProperty);
        Task<ResidentialProperty> Put(ResidentialProperty residencialProperty);
        Task<bool> Delete(Guid id);
    }
}