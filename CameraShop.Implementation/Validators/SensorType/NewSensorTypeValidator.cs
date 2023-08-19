using CameraShop.Application.Dto.SensorTypeDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.SensorType
{
    public class NewSensorTypeValidator : AbstractValidator<NewSensorTypeDto>
    {
        public NewSensorTypeValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory").Must(x => !context.SensorTypes.Any(y => y.Type == x)).WithMessage("That name is already taken").Matches("^[A-Z][A-z1-9 ]{3,10}$").WithMessage("Brand name must beggin with capital letter, min 4 and max 10 characters");
        }
    }
}
