using DePoisty.RestaurantFoodsService.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DePoisty.RestaurantFoodsService.Persistence.Data.Configurations
{
    public class RestaurantMetaConfiguration : IEntityTypeConfiguration<RestaurantMeta>
    {
        public void Configure(EntityTypeBuilder<RestaurantMeta> builder)
        {
            builder.Property(rm => rm.RestaurantId)
                .IsRequired();

            builder.Property(rm => rm.ParsingType)
                .IsRequired();

            builder.Property(rm => rm.ParsingClassName)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
