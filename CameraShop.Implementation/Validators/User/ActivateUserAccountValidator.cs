using CameraShop.Application.Dto;
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
    public class ActivateUserAccountValidator : AbstractValidator<UserActivisionLinkDto>
    {
        public ActivateUserAccountValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.ActivisionId).NotNull().WithMessage("Activision link must not be empty").Must(x => context.Users.Any(y => y.UniqueActivisonCode == x)).WithMessage("Acitivison link not found").Must(x=> !context.Users.Where(y=>y.UniqueActivisonCode == x).FirstOrDefault().IsAccountActivated).WithMessage("Your account is already activated");

        }
    }
}
