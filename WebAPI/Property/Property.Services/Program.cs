using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Property.Services.Data;
using Property.Services.Repositories;
using Property.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
//builder.Services.AddScoped<IPropertiesRepository, PropertiesRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("PropertyConnection")
    ));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
