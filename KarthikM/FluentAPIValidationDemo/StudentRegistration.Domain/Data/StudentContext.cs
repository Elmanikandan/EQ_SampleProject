using StudentRegistration.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistration.Domain.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) 
        { 

        }
        protected override void OnModelCreating(ModelBuilder builder) { 
            base.OnModelCreating(builder); 
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<SubjectGpa> SubjectGpas { get; set; }
        public DbSet<Result> Results { get; set; }
    }
}
