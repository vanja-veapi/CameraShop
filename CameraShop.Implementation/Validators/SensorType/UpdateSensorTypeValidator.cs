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
    public class UpdateSensorTypeValidator : AbstractValidator<UpdateSensorTypeDto>
    {
        public UpdateSensorTypeValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.IdToUpdate).NotNull().WithMessage("Id must not be null").Must(x => context.SensorTypes.Any(y => y.Id == x)).WithMessage("Given sensor type id not found");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is mandatory").Must(x => !context.SensorTypes.Any(y => y.Type == x)).WithMessage("That name is already taken").Matches("^[A-Z][A-z0-9 ]{3,10}$").WithMessage("Brand name must beggin with capital letter, min 4 and max 11 characters");
        }
    }
}
