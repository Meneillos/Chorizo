using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chorizo.Models;
using Chorizo.Models.School;
using Microsoft.EntityFrameworkCore;

namespace Chorizo.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Subject> Subject { get; set; } = null!; //=> Set<Subject>();
        public DbSet<Person> Person { get; set; } = null!;//=> Set<Person>();
        public DbSet<Enrollment> Enrollment { get; set; } = null!;//=> Set<Enrollment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}