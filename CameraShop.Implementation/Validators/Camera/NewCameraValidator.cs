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
    public class NewCameraValidator : AbstractValidator<NewCameraDto>
    {
        public NewCameraValidator(CameraShopDbContext context, ImageValidator imageValidator)
        {
            RuleFor(x => x.BlueThoothSupport).NotNull().WithMessage("BluetoothSupport field is manditory");

            RuleFor(x => x.WifiSupport).NotNull().WithMessage("WifiSupport field is manditory");

            RuleFor(x => x.VideoResolution).NotEmpty().WithMessage("VideoResolution field is manditory").Matches("^[1-90]{1,}$").WithMessage("VideoResolution must be typed only using numbers");

            RuleFor(x => x.SensorTypeId).NotEmpty().WithMessage("SensorTypeId field is manditory").Must(x=> context.SensorTypes.Any(y=>y.Id == x)).WithMessage("Sensor type id not found");

            RuleFor(x => x.Price).NotEmpty().WithMessage("BluetoothSupport field is manditory").Must(x=> x > 0).WithMessage("Price must be a positive number");

            RuleFor(x => x.Name).NotEmpty().WithMessage("BluetoothSupport field is manditory").Matches("^[A-Z][A-z1-90 ]{3,29}$").WithMessage("Name must beggin with capital letter, min 4 and max 30 characters").Must(x => !context.Cameras.Any(y => y.Name == x)).WithMessage("Camera name already exists");

            RuleFor(x => x.MegaPixels).NotEmpty().WithMessage("MegaPixels field is manditory");

            RuleFor(x => x.LensMount).NotNull().WithMessage("LensMount field is manditory");

            RuleFor(x => x.ISO).NotEmpty().WithMessage("ISO field is manditory").Matches("^[1-90]{1,}$").WithMessage("ISO must be typed only using numbers");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description field is manditory").MaximumLength(255).WithMessage("Maximum character length is 255");

            RuleFor(x => x.BrandId).NotEmpty().WithMessage("BluetoothSupport field is manditory").Must(x=> context.Brands.Any(y=>y.Id == x)).WithMessage("Given brand id does not exist");

            RuleFor(x => x.Discount).Must(y =>
            {
                if (y == null)
                {
                    return true;
                }
                else
                {
                    var errors = "";

                    if (y.DiscountPercentage == null || y.DiscountPercentage == 0)
                    {
                        errors += "++";
                    }
                    if(y.StartDate == null )
                    {
                        errors += "++";
                    }
                    else if(y.EndDate != null)
                    {
                        errors += "++";
                    }
                    else if (y.EndDate < y.StartDate || y.EndDate < DateTime.UtcNow || y.StartDate < DateTime.UtcNow)
                    {
                        errors += "++";
                    }

                    return errors == "";
                }
            }).WithMessage("Discount percentage must be more than 0, and end date must be in the future");

            RuleForEach(x => x.Pictures).NotEmpty().WithMessage("There must be atleast 1 picture").SetValidator(imageValidator);
            RuleFor(x => x.indexOfPrimary).NotNull();
        }
    }
}
