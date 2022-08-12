namespace CarRentingSystem.Data.Configurations
{
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder
                .HasKey(d => d.Id);

            builder
                .HasMany(d => d.Cars)
                .WithOne(c => c.Dealer)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(d => d.User)
                .WithOne()
                .HasForeignKey<Dealer>(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
