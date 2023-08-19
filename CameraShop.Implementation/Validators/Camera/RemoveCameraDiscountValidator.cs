using CameraShop.Application.Dto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Camera
{
    public class RemoveCameraDiscountValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveCameraDiscountValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Camera discount id is mandatorty").Must(x => context.Discounts.Any(y => y.Id == x)).WithMessage("Camera discount id not found");

        }
    }
}
