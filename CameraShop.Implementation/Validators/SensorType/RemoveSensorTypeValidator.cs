using CameraShop.Application.Dto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.SensorType
{
    public class RemoveSensorTypeValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveSensorTypeValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id must not be null").Must(x => context.SensorTypes.Any(y => y.Id == x)).WithMessage("Given sensor type id not found").Must(x => !context.Cameras.Any(y => y.SensorTypeId == x)).WithMessage("Unable to remove this sensor type since it is used by the cameras");
        }
    }
}
