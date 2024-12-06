using Microsoft.EntityFrameworkCore;
using WwatermelonWebsite.Models;

namespace WwatermelonWebsite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<BrandAction> BrandActions { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>()
                .ToTable("Brands", schema: "dbo");

            modelBuilder.Entity<Request>()
                .ToTable("Requests", schema: "dbo");

        }
    }
}

