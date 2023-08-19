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
    public class CreateNewUserValidator : AbstractValidator<NewUserDto>
    {
        public CreateNewUserValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is mandatory").Must(x => !context.Users.Any(y => y.UserName == x)).WithMessage("Username is already taken").Matches("^[A-z1-90]{5,25}$").WithMessage("User name must be at minimum 5 characters and maximum of 25");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password must not be empty").MaximumLength(30).WithMessage("Maximum length is 30 characters").MinimumLength(5).WithMessage("Minimum length is 5 characters").Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{5,30}$").WithMessage("Password need atleast 1 uppercase letter, 1 lowercase letter and one number");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email address must not be empty").Must(x => !context.Users.Any(y => y.Email == x)).WithMessage("Email address is already taken").EmailAddress().WithMessage("Email address is not valid");

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Name must not be empty").MaximumLength(20).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").WithMessage("Name must begin with Capital letter");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name must not be empty").MaximumLength(20).WithMessage("Maximum length is 20 characters").Matches(@"^[A-Z][a-z]{1,19}$").WithMessage("Last name must begin with Capital letter");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is mandatory").Matches("^[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}$").WithMessage("Phone number is not in correct format ").Must(x=> !context.Users.Any(y=>y.PhoneNumber == x)).WithMessage("Phone number is already in the use");

            RuleFor(x => x.Address).NotEmpty().WithMessage("Phone number is mandatory");
        }
    }
}
