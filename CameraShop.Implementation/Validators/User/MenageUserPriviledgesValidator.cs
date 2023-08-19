using CameraShop.Application.Dto.UserDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.User
{
    public class MenageUserPriviledgesValidator : AbstractValidator<MenageUserPrivelegdesDto>
    {
        public MenageUserPriviledgesValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.UserId).NotNull().WithMessage("User id is mandatory").Must(x => context.Users.Any(y => y.Id == x)).WithMessage("User id not found");

            RuleFor(x => x.UseCaseId).NotNull().WithMessage("Use case identifier is mandatory").Must(x => context.UseCases.Any(y => y.Id == x)).WithMessage("Use case identifier not found");
        }
    }
}
