using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Property.Services.Models;

namespace Property.Services.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<Properties> Properties { get; set; }
        public DbSet<Occupancy> Occupancny { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    }
}
