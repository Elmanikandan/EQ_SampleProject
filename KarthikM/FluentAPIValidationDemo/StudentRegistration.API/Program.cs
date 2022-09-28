using StudentRegistration.Domain.Data;
using Microsoft.EntityFrameworkCore;
using Repository.IRepository;
using Repository.Repository;
using StudentRegistration.Domain.Models;
using StudentRegistration.Service.CustomServices;
using StudentRegistration.Service.ICustomServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<StudentContext>(
        i => i.UseSqlServer(builder.Configuration.GetConnectionString("DBConnection")
    ));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service Injected 
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Student>, StudentService>();
builder.Services.AddScoped<ICustomService<Result>, ResultService>();
builder.Services.AddScoped<ICustomService<Department>, DepartmentService>();
builder.Services.AddScoped<ICustomService<SubjectGpa>, SubjectGpaService>();
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
