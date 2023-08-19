using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class DiscountConfiguration : EntityConfiguration<Discount>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(x => x.DiscountPercentage).IsRequired();
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.EndDate).IsRequired();

        }
    }
}
