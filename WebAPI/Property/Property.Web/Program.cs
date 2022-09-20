using Property.Web.Models;
using Property.Web.Services.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.Configure<ApiUrls>(builder.Configuration.GetSection(ApiUrls.API_URL_SECTION));
    builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
    builder.Services.AddControllersWithViews();
}
