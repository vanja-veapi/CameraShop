using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class UseCaseConfiguration : EntityConfiguration<UseCase>
    {
        protected override void ConfigureRules(EntityTypeBuilder<UseCase> builder)
        {

            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.UseCaseNumber).IsRequired().HasMaxLength(255);

            builder.HasMany(x => x.UserUseCases).WithOne(x => x.UseCase).HasForeignKey(x => x.UseCaseId).OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.UseCaseLogs).WithOne(x => x.UseCase).HasForeignKey(x => x.UseCaseId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
