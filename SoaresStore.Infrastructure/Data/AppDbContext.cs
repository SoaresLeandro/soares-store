using Microsoft.EntityFrameworkCore;
using SoaresStore.Domain.Entities;

namespace SoaresStore.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
        }
    }
}
