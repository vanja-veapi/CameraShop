using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class StockPlaceConfiguration : EntityConfiguration<StockPlace>
    {
        protected override void ConfigureRules(EntityTypeBuilder<StockPlace> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Longitude).IsRequired();
            builder.Property(x => x.latitude).IsRequired();

        }
    }
}
