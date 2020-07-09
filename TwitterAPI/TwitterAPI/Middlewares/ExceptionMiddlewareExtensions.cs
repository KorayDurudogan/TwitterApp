using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using TwitterAPI.Models.Logging;

namespace TwitterAPI.Middlewares
{
    /// <summary>
    /// A middleware for logging exceptions around the whole app.
    /// </summary>
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            builder.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    ExceptionHandlerFeature contextFeature = context.Features.Get<IExceptionHandlerFeature>() as ExceptionHandlerFeature;
                    var error = new ErrorLog(contextFeature?.Error?.Message, contextFeature?.Error?.StackTrace);

                    var errorManager = new LogManager(error);
                    errorManager.MakeLogging();
                });
            });

            return builder;
        }
    }
}
