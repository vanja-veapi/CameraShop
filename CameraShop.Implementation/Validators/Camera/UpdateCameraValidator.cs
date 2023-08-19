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
    public class UpdateCameraValidator : AbstractValidator<UpdateCameraDto>
    {
        public UpdateCameraValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.CameraId).NotEmpty().WithMessage("Camera id must not be empty").Must(x => context.Cameras.Any(y => y.Id == x)).WithMessage("Camera id not found");

            RuleFor(x => x.VideoResolution).Matches("^[1-90]{1,}$").When(x => !string.IsNullOrEmpty(x.VideoResolution)).WithMessage("VideoResolution must be typed only using numbers");

            RuleFor(x => x.SensorTypeId).Must(x => context.SensorTypes.Any(y => y.Id == x)).When(x => x.SensorTypeId != null).WithMessage("Sensor type id not found");

            RuleFor(x => x.Price).Must(x => x > 0).When(x => x.Price != null).WithMessage("Price must be a positive number");

            RuleFor(x => x.Name).Matches("^[A-Z][A-z1-90 ]{3,29}$").When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("Name must beggin with capital letter, min 4 and max 30 characters").Must(x => !context.Cameras.Any(y => y.Name == x)).When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("Camera name already exists");


            RuleFor(x => x.ISO).Matches("^[1-90]{1,}$").When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("ISO must be typed only using numbers");

            RuleFor(x => x.Description).MaximumLength(255).When(x => !string.IsNullOrEmpty(x.Description)).WithMessage("Maximum character length is 255");

            RuleFor(x => x.BrandId).Must(x => context.Brands.Any(y => y.Id == x)).When(x => x.BrandId != null).WithMessage("Given brand id does not exist");
        }
    }
}
