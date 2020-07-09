using Microsoft.AspNetCore.Http;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using TwitterAPI.DAO;

namespace TwitterAPI.Models.Token
{
    public class LogedInUserProviderByToken : ILogedInUserProvider<User>
    {
        private readonly IHttpContextAccessor HttpContextAccessor;
        private readonly IDAO<User> UserDao;

        public LogedInUserProviderByToken(IHttpContextAccessor HttpContextAccessor, IDAO<User> _userDao)
        {
            this.HttpContextAccessor = HttpContextAccessor;
            this.UserDao = _userDao;
        }

        public User GetLogedInUser()
        {
            Claim idClaim = this.HttpContextAccessor.HttpContext.User.Claims.Where(c => c.Type == JwtRegisteredClaimNames.Jti).FirstOrDefault();
            if (idClaim != null)
            {
                int id = Convert.ToInt32(idClaim.Value);
                return UserDao.Get(id);
            }
            else
            {
                throw new Exception("Token corrupted !");
            }
        }
    }
}
