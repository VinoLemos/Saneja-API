using Api.Domain.Dtos;
using Domain.Dtos;
using Domain.Interfaces.Services.TokenServices;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TokenServices
{
    public class UserTokenService : IUserTokenService
    {
        private readonly IConfiguration _configuration;

        public UserTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public UserTokenDto GenerateToken(LoginDto login)
        {
            // User declarations
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, login.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Generates a key based on a simetric algorithm
            var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // Generates digital signature using HMAC and private key
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Expiration Time
            var expirationTime = _configuration["TokenConfiguration:ExpireHours"];
            var expirationDate = DateTime.UtcNow.AddHours(double.Parse(expirationTime));

            // Generates the Token
            var token = new JwtSecurityToken(
                issuer: _configuration["TokenConfiguration:Issuer"],
                audience: _configuration["TokenConfiguration:Audience"],
                claims: claims,
                expires: expirationDate,
                signingCredentials: credentials);

            return new UserTokenDto()
            {
                Authenticated = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expirationDate,
                Message = "Token Jwt Created"
            };
        }
    }
}
