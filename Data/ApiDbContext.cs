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

        public DbSet<Subject> Subject => Set<Subject>();
        public DbSet<Person> Person => Set<Person>();
        public DbSet<Enrollment> Enrollment => Set<Enrollment>();
    }
}