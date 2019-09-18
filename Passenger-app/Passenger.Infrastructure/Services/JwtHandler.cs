using System.Text;
using System;
using Passenger.Infrastructure.DTO;
using Passenger.Infrastructure.Settings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Passenger.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;


namespace Passenger.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _settings;
        public JwtHandler(IOptions<JwtSettings> settings)
        {
            _settings = settings.Value;
        }
        public JwtDto CreateToken(string email)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
               // new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var expires = now.AddMinutes(_settings.ExpiryMinutes);
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key)
                , SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: _settings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            
            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimeStamp()
            };
        }
    }
}