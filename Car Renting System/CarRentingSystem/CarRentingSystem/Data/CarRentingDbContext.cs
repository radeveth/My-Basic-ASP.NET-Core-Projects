namespace CarRentingSystem.Data
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CarRentingSystem.Data.Models;

    public class CarRentingDbContext : IdentityDbContext
    {
        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Car>
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars).HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(builder);
        }
    }
}