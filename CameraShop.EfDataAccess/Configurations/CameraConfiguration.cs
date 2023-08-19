using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class CameraConfiguration : EntityConfiguration<Camera>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Camera> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Megapixels).IsRequired();
            builder.Property(x => x.ISO).IsRequired();
            builder.Property(x => x.VideoResolution).IsRequired();
            builder.Property(x => x.WifiSupport).IsRequired();
            builder.Property(x => x.BluetoothSupport).IsRequired();
            builder.Property(x => x.LensMount).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasIndex(x => x.Name).IsUnique();

            //builder.HasOne(x => x.Brand).WithMany(x => x.Cameras).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.SensorType).WithMany(x => x.Cameras).HasForeignKey(x => x.SensorTypeId).OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.CameraImages).WithOne(x => x.Camera).HasForeignKey(x => x.CameraId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.CartItems).WithOne(x => x.Camera).HasForeignKey(x => x.CameraId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Discounts).WithOne(x => x.Camera).HasForeignKey(x => x.CameraId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Stocks).WithOne(x => x.Camera).HasForeignKey(x => x.CameraId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
