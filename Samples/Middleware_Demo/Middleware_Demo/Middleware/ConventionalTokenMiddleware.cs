using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Middleware_Demo.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ConventionalTokenMiddleware
    {
        private readonly RequestDelegate _next;

        public ConventionalTokenMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ConventionalTokenMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalTokenMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ConventionalTokenMiddleware>();
        }
    }
}
