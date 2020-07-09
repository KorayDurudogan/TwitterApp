using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using TwitterAPI.DAO;
using TwitterAPI.Models;
using TwitterAPI.Models.Token;
using TwitterAPI.ViewModels;

namespace TwitterAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMapper Mapper;
        private readonly IDAO<User> UserDao;
        private readonly ITokenProvider TokenProvider;

        public AuthController(IMapper _mapper, IDAO<User> _userDao, ITokenProvider _tokenProvider)
        {
            this.Mapper = _mapper;
            this.UserDao = _userDao;
            this.TokenProvider = _tokenProvider;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UserVM user_vm)
        {
            var users = UserDao.Get() as List<User>;
            User logedInUser = users?.Where(u => u.EMail.Equals(user_vm.EMail) && u.Password.Equals(user_vm.Password)).FirstOrDefault();

            if (logedInUser != null)
            {
                var token = TokenProvider.GetToken(logedInUser.Id);
                return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token), message = "success" });
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserVM user_vm)
        {
            User user = Mapper.Map<User>(user_vm);
            UserDao.Insert(user);
            return Ok(new { message = "success" });
        }

        [HttpGet]
        [Route("is_live")]
        public IActionResult IsLive()
        {
            return Ok("Server lives !");
        }
    }
}
