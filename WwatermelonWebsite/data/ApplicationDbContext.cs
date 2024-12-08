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

        public DbSet<RequestModel> RequestModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Brand>()
                .ToTable("Brands", schema: "dbo");

            modelBuilder.Entity<RequestModel>()
                .ToTable("Requests", schema: "dbo");

        }
    }
}

