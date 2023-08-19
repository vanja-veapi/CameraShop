using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class CameraImageConfiguration : EntityConfiguration<CameraImage>
    {
        protected override void ConfigureRules(EntityTypeBuilder<CameraImage> builder)
        {
            builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IsPrimary).IsRequired().HasDefaultValue(false);

        }
    }
}
