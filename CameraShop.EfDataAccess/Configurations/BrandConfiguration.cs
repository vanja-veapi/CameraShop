using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class BrandConfiguration : EntityConfiguration<Brand>
    {
        protected override void ConfigureRules(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.BrandName).IsRequired().HasMaxLength(100);

            builder.HasIndex(x => x.BrandName).IsUnique();

            builder.HasMany(x => x.Cameras).WithOne(x => x.Brand).HasForeignKey(x => x.BrandId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
