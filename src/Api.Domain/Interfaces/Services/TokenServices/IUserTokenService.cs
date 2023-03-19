using Api.Domain.Dtos;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.TokenServices
{
    public interface IUserTokenService
    {
        UserTokenDto GenerateToken(LoginDto login);
    }
}
