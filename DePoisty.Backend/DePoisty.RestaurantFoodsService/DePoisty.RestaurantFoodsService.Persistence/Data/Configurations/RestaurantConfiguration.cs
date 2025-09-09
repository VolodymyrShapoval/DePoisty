using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Configurations
{
    public class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.Property(r => r.Name)
                .HasMaxLength(100);

            builder.Property(r => r.Address)
                .HasMaxLength(250);

            builder.Property(r => r.Website)
                .HasMaxLength(2083)
                .IsRequired();


            builder.HasMany(r => r.Dishes)
                .WithOne(d => d.Restaurant)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.RestaurantMeta)
                .WithOne(m => m.Restaurant)
                .HasForeignKey<RestaurantMeta>(m => m.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        }
    }
}
