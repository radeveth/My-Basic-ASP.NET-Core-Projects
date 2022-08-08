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
<<<<<<< Updated upstream
        public DbSet<Car> Cars { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
=======

        public DbSet<Car> Cars { get; init; }
        public DbSet<Category> Categories { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration[""ConnectionStrings: DefaultConnection""]);
            }

            base.OnConfiguring(optionsBuilder);
        }
>>>>>>> Stashed changes

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new DealerConfiguration());

            base.OnModelCreating(builder);
        }

    }
}