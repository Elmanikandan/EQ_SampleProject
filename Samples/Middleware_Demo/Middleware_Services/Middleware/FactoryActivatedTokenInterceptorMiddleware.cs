namespace Middleware_Services.Middleware
{
    public class FactoryActivatedTokenInterceptorMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await context.Response.WriteAsync("\nRequest: Factory based middleware\n");
            await next(context);
            await context.Response.WriteAsync("\nResponse: Factory based middleware\n");
            //throw new NotImplementedException();
        }
    }
}
