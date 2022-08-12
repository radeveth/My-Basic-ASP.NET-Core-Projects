namespace CarRentingSystem.Data.Configurations
{

    using CarRentingSystem.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .HasMany(c => c.Cars)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
