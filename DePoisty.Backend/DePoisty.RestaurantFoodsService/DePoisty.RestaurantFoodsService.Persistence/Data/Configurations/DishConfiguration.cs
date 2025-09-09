using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.Property(d => d.RestaurantId)
                .IsRequired();

            builder.Property(d => d.Category)
                .IsRequired();

            builder.Property(d => d.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(d => d.Price)
                .IsRequired();

            builder.Property(d => d.Weight)
                .IsRequired();
        }
    }
}
