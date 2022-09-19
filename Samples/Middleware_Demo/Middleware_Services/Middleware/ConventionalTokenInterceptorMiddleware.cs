using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Middleware_Services.Services;
using System.Threading.Tasks;

namespace Middleware_Services.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalTokenInterceptorMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ITokenInterceptorService _tokenInterceptorService;

        public ConventionalTokenInterceptorMiddleware(RequestDelegate next, ITokenInterceptorService tokenInterceptorService)
        {
            _next = next;
            _tokenInterceptorService = tokenInterceptorService;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (_tokenInterceptorService.InterceptToken(httpContext))
            {
                await _next(httpContext);
            }
            else
            {
                await httpContext.Response.WriteAsync("\n no auth header \n");
            }
          
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class ConventionalTokenInterceptorMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseConventionalTokenInterceptorMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<ConventionalTokenInterceptorMiddleware>();
    //    }
    //}
}
