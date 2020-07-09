using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TwitterAPI.Filters;
using TwitterAPI.Models;
using TwitterAPI.Models.Token;

namespace TwitterAPI.Controllers
{
    /// <summary>
    /// Base controller for authenticated users.
    /// </summary>
    [Authorize]
    [ServiceFilter(typeof(InfoLogActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class TwitterController : ControllerBase
    {
        private readonly ILogedInUserProvider<User> UserProvider;
        protected User CurrentUser;

        public TwitterController(ILogedInUserProvider<User> userProvider)
        {
            this.UserProvider = userProvider;
            this.CurrentUser = this.UserProvider.GetLogedInUser();
        }
    }
}