using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Taskify.Domain;

namespace Taskify.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks => Set<TaskItem>();    
    }
}
