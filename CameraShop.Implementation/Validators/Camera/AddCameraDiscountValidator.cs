using CameraShop.Application.Dto.CameraDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Camera
{
    public class AddCameraDiscountValidator : AbstractValidator<CameraOnDiscountDto>
    {
        public AddCameraDiscountValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.IdCamera).NotEmpty().WithMessage("Camera id is manditory").Must(x=> context.Cameras.Any(y=>y.Id == x)).WithMessage("Id camera does not exist").Must(x=> context.Discounts.Where(y=>y.CameraId == x).OrderByDescending(y=>y.EndDate).Select(m=>m.EndDate).FirstOrDefault() < DateTime.UtcNow).WithMessage("Selected camera already have an active discount");

            RuleFor(x => x.DiscountPercentage).NotEmpty().WithMessage("Discount is manditory").Must(x => x <= 100 && x > 0).WithMessage("Maximum is 100% and minimum is 1%");

            RuleFor(x => x.StartsOn).NotEmpty().WithMessage("Start date is mandatory").Must(x => x >= DateTime.UtcNow).WithMessage("Start cant be in the past");

            RuleFor(x => x.EndsOn).NotEmpty().WithMessage("End date is manditory").Must((x,y) => 
            {
                return x.EndsOn > x.StartsOn;
            });
        }
    }
}
