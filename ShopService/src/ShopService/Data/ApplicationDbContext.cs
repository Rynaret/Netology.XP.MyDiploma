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

            builder.Entity<DeliveryInterval>()
                .Property(f => f.CronString)
                .HasMaxLength(120);

            builder.Entity<DeliveryIntervalTemplate>()
                .Property(f => f.CronFormatMonthFrequency)
                .HasMaxLength(5);
            builder.Entity<DeliveryIntervalTemplate>()
                .Property(f => f.DatesCountInMonth)
                .HasMaxLength(31);
            builder.Entity<DeliveryIntervalTemplate>()
                .Property(f => f.Name)
                .HasMaxLength(100);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<DeliveryInterval> DeliveryIntervals { get; set; }
        public DbSet<SubscriptionDate> SubscriptionDates { get; set; }
        public DbSet<DeliveryIntervalTemplate> DeliveryIntervalTemplates { get; set; }
    }
}
