using CameraShop.Application.Dto.BrandDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Brand
{
    public class NewCameraBrandValidator : AbstractValidator<NewCameraBrandDto>
    {
        public NewCameraBrandValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty").Must(x => !context.Brands.Any(y => y.BrandName == x)).WithMessage("Brand name already exists").Matches("^[A-Z][A-z1-9 ]{3,10}$").WithMessage("Brand name must beggin with capital letter, min 4 and max 11 characters");

        }
    }
}
