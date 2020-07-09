using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TwitterAPI.Models.Token;

namespace TwitterAPI.Models
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration Configuration;

        public TokenProvider(IConfiguration _configuration)
        {
            this.Configuration = _configuration;
        }

        public JwtSecurityToken GetToken(int id)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, id.ToString())
            };

            return new JwtSecurityToken
            (
                issuer: Configuration[Constants.Issuer],
                audience: Configuration[Constants.Key],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(30),
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration[Constants.SigningKey])),
                    SecurityAlgorithms.HmacSha256)
            );
        }
    }
}
