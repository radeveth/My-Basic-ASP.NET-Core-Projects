namespace CarRentingSystem.Data
{

    using CarRentingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CarRentingSystem.Data.Configurations;

    public class CarRentingDbCotext : IdentityDbContext
    {
        public CarRentingDbCotext(DbContextOptions<CarRentingDbCotext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}