using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class OrderConfiguration : EntityConfiguration<Order>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.TotalAmount).IsRequired();

            builder.HasOne(x => x.Cart).WithOne(x => x.Order).HasForeignKey<Order>(x => x.CartId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
