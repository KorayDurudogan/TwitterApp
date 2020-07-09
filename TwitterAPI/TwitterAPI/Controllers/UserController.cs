using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterAPI.DAO;
using TwitterAPI.Models;
using TwitterAPI.Models.Token;
using TwitterAPI.ViewModels;

namespace TwitterAPI.Controllers
{
    public class UserController : TwitterController
    {
        private readonly IContact Contact;
        private readonly IDAO<User> UserDao;
        private readonly IMapper Mapper;

        public UserController(ILogedInUserProvider<User> userProvider, IDAO<User> userDao, IMapper mapper) : base(userProvider)
        {
            this.Contact = new Contact(this.CurrentUser);
            this.UserDao = userDao;
            this.Mapper = mapper;
        }

        [HttpPut]
        [Route("follow")]
        public async Task<IActionResult> Follow(IdentityVM identity)
        {
            this.Contact.Follow(identity.Id);
            return Ok();
        }

        [HttpPut]
        [Route("unfollow")]
        public async Task<IActionResult> Unfollow(IdentityVM identity)
        {
            this.Contact.Unfollow(identity.Id);
            return Ok();
        }

        /// <summary>
        /// Returns all users except logedin one.
        /// </summary>
        /// <returns>Users. <see cref="IEnumerable{T}"/> <seealso cref="User"/></returns>
        [HttpGet]
        public async Task<IEnumerable<IdentityVM>> Get()
        {
            IEnumerable<User> users = this.UserDao.Get()?.Where(u => u.Id != this.CurrentUser.Id);
            List<IdentityVM> viewModelUsers = users.Select(u => Mapper.Map<IdentityVM>(u)).ToList();

            //Setting if user followed by logedin user or not.
            viewModelUsers.ForEach(v => { v.IsFollowed = this.CurrentUser.Following.Contains(v.Id); });

            return viewModelUsers;
        }
    }
}
