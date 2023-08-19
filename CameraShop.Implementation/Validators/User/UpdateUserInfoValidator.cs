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
    public class UpdateUserInfoValidator : AbstractValidator<UpdateUserDataDto>
    {
        public UpdateUserInfoValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("UserId id must not be empty").Must(x => context.Users.Any(y => y.Id == x)).WithMessage("UserId not found");

            RuleFor(x => x.FirstName).MaximumLength(20).When(x => !string.IsNullOrEmpty(x.FirstName)).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").When(x => !string.IsNullOrEmpty(x.FirstName)).WithMessage("Name must begin with Capital letter");

            RuleFor(x => x.LastName).MaximumLength(20).When(x => !string.IsNullOrEmpty(x.LastName)).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").When(x => !string.IsNullOrEmpty(x.LastName)).WithMessage("Last name must begin with Capital letter");

            RuleFor(x => x.PhoneNumber).Matches("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$").When(x => !string.IsNullOrEmpty(x.PhoneNumber)).WithMessage("Phone number is not in correct format ");

        }
    }
}
