using System.IdentityModel.Tokens.Jwt;

namespace TwitterAPI.Models.Token
{
    public interface ITokenProvider
    {
        JwtSecurityToken GetToken(int email);
    }
}
