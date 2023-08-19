using CameraShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CameraShop.EfDataAccess.Configurations
{
    public class UserUseCaseConfiguration : EntityConfiguration<UserUseCase>
    {
        protected override void ConfigureRules(EntityTypeBuilder<UserUseCase> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.UserUseCases).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
