using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class UseCaseLogConfiguration : EntityConfiguration<UseCaseLog>
    {
        protected override void ConfigureRules(EntityTypeBuilder<UseCaseLog> builder)
        {
            builder.Property(x=>x.ExecutionDateTime).IsRequired().HasDefaultValueSql("GETDATE()");

            builder.HasOne(x => x.User).WithMany(x => x.UseCaseLogs).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
