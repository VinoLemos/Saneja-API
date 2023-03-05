using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService<T> where T: BaseUser
    {
        Task<T> FindByLogin(T user);
    }
}