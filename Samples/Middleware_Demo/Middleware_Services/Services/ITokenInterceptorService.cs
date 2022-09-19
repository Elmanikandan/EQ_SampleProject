namespace Middleware_Services.Services
{
    public interface ITokenInterceptorService
    {
        bool InterceptToken(HttpContext context);
    }
}
