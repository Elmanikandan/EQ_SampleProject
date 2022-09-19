using Middleware_Demo.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//Middlewares
app.UseConventionalTokenMiddleware();

app.Run();
