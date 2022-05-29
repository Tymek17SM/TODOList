using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Threading.Tasks;
using WebAPI.Exceptions;
using WebAPI.Wrappers;

namespace WebAPI.Middelwares
{
    public class ErrorHandlingMiddelware : IMiddleware
    {
        private readonly ILogger _logger;

        public ErrorHandlingMiddelware(ILogger<ErrorHandlingMiddelware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(NotFoundException ex)
            {
                _logger.LogWarning(ex, ex.Message);

                context.Response.StatusCode = 404;
                await context.Response.WriteAsJsonAsync(new Response(false, ex.Message));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"{ex.Message}\n{ex.StackTrace}");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsJsonAsync(new Response(false, "Something went wrong."));
            }
        }
    }
}
