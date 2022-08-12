namespace CarRentingSystem.Data.Configurations
{

    using CarRentingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasOne(c => c.Category)
                .WithMany(c => c.Cars)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Dealer)
                .WithMany(d => d.Cars)
                .HasForeignKey(c => c.DealerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
