using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopService.Entities;

namespace ShopService.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();
            builder.Entity<Product>()
                .Property(f => f.Name)
                .HasMaxLength(200);
        }

        public DbSet<Product> Products { get; set; }
    }
}
