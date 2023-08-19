using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class SensorTypeConfiguration : EntityConfiguration<SensorType>
    {

        protected override void ConfigureRules(EntityTypeBuilder<SensorType> builder)
        {
            builder.Property(x => x.Type).IsRequired();

            builder.HasIndex(x => x.Type).IsUnique();
        }
    }
}
