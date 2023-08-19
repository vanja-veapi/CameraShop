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
    public class RemoveCameraValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveCameraValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Camera id is mandatorty").Must(x => context.Cameras.Any(y => y.Id == x)).WithMessage("Camera id not found").Must(x => !context.CartItems.Any(y => y.CameraId == x)).WithMessage("This camera has been used in carts, and been bought - unable do remove this item");

        }
    }
}
