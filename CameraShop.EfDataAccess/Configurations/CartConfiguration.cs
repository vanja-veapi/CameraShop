using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class CartConfiguration : EntityConfiguration<Cart>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Cart> builder)
        {
            builder.Property(x => x.ActiveCart).HasDefaultValue(true);
            builder.Property(x => x.MovedToOrder).HasDefaultValue(false);

            builder.HasOne(x => x.User).WithMany(x => x.Carts).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Order).WithOne(x => x.Cart).HasForeignKey<Cart>(x => x.OrderId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CartItems).WithOne(x => x.Cart).HasForeignKey(x => x.CartId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
