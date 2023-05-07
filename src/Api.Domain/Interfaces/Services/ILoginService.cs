using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services
{
    public interface ILoginService<T> where T : User
    {
        Task<object> FindByLogin(LoginDto user);
    }
}