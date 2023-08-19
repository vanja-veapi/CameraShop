using CameraShop.Application.Dto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Brand
{
    public class RemoveBrandValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveBrandValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id must not be empty").Must(x=> context.Brands.Any(y=>y.Id == x)).WithMessage("Given id does not exist").Must(x=> !context.Cameras.Any(y=>y.BrandId == x)).WithMessage("Unable to remove this brand since it is used by the cameras");
        }
    }
}
