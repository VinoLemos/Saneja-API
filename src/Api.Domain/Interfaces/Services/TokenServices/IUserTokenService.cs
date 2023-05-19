using Api.Domain.Dtos;
using Domain.Dtos;

namespace Domain.Interfaces.Services.TokenServices
{
    public interface IUserTokenService
    {
        UserTokenDto GenerateToken(LoginDto login, List<string>? roles, Guid? id);
    }
}
