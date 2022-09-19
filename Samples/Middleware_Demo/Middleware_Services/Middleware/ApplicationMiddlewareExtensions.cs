namespace Middleware_Services.Middleware
{
    public static class ApplicationMiddlewareExtensions
    {
        public static IApplicationBuilder UseConventionalTokenInterceptor(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ConventionalTokenInterceptorMiddleware>();
        }
        public static IApplicationBuilder UseFactoryBasedTokenInterceptor(this IApplicationBuilder applicationBuilder)
        {            
            return applicationBuilder.UseMiddleware<FactoryActivatedTokenInterceptorMiddleware>();
        }
    }
}
