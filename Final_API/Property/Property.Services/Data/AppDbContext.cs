using Microsoft.EntityFrameworkCore;
using Property.Services.Models;

namespace Property.Services.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Properties> Properties { get; set; }   

    }
}
