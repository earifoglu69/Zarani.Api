using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zarani.Infrastructure.Extentions;
using Zarani.Infrastructure.Models;
namespace Zarani.Infrastructure.Context
{
    public class ZaraniDbContext : IdentityDbContext<ApplicationUser>
    {

        public ZaraniDbContext( DbContextOptions<ZaraniDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<ModuleEntity> Modules { get; set; } = null!;
        public DbSet<ContentEntity> Contents { get; set; } = null!;
    }
}
