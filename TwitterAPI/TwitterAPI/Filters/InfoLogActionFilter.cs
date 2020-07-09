using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;
using TwitterAPI.Models;
using TwitterAPI.Models.Logging;
using TwitterAPI.Models.Token;

namespace TwitterAPI.Filters
{
    public class InfoLogActionFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor HttpContextAccessor;

        private readonly ILogedInUserProvider<User> LogedinUserProvider;

        public InfoLogActionFilter(IHttpContextAccessor _httpContextAccessor, ILogedInUserProvider<User> logedinUserProvider)
        {
            this.HttpContextAccessor = _httpContextAccessor;
            this.LogedinUserProvider = logedinUserProvider;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            User user = LogedinUserProvider.GetLogedInUser();

            string log = String.Format("{0} - {1}", user?.EMail, HttpContextAccessor.HttpContext.Request.Path.Value);
            var infoLog = new InfoLog(log);

            var infoLogManager = new LogManager(infoLog);
            infoLogManager.MakeLogging();

            await next();
        }
    }
}
