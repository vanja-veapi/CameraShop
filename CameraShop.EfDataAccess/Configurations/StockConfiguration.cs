using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class StockConfiguration : EntityConfiguration<Stock>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Stock> builder)
        {
            builder.Property(x => x.Quantity).IsRequired();

            builder.HasOne(x => x.StockPlace).WithMany(x => x.Stocks).HasForeignKey(x => x.StockPlaceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
