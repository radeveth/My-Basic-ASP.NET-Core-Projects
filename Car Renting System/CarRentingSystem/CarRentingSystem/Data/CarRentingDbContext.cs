namespace CarRentingSystem.Data
{

    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using CarRentingSystem.Data.Models;

    public class CarRentingDbContext : IdentityDbContext
    {
        private readonly IConfiguration configuration;

        public CarRentingDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public CarRentingDbContext(DbContextOptions<CarRentingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; init; }
        public DbSet<Category> Categories { get; init; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}