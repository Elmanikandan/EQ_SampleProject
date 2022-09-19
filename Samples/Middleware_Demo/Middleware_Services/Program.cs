using Middleware_Services.Middleware;
using Middleware_Services.Services;

var builder = WebApplication.CreateBuilder(args);

//Services
builder.Services.AddTransient<FactoryActivatedTokenInterceptorMiddleware>();
builder.Services.AddTransient<ITokenInterceptorService, TokenInterceptorService>();


var app = builder.Build();

//Middleware
app.UseConventionalTokenInterceptor();
app.UseFactoryBasedTokenInterceptor();

app.Use(
       async (context, next) =>
       {
           await context.Response.WriteAsync("1. middleware1 request\n");
           await next();
           await context.Response.WriteAsync("2. middleware1 response\n");
       }
    );
app.Use(
   async (context, next) =>
   {
       await context.Response.WriteAsync("3. middleware2 request\n");
       await next();
       await context.Response.WriteAsync("4. middleware2 response\n");
   }
);


app.Run(
   async (context) =>
   {
       await context.Response.WriteAsync("Hello World!\n");
   }
);

app.Run();
