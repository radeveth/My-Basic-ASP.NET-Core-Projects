namespace CarRentingSystem.Data
{

    using CarRentingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CarRentingSystem.Data.Configurations;

    public class CarRentingDbContext : IdentityDbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());

            base.OnModelCreating(builder);
        }

    }
}