namespace Middleware_Services.Services
{
    public class TokenInterceptorService : ITokenInterceptorService
    {
        public bool InterceptToken(HttpContext context)
        {
            return true;
            //throw new NotImplementedException();
        }
    }
}
