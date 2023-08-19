using CameraShop.Application.Dto.SensorTypeDto;
using CameraShop.Application.UseCases.SensorTypeUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.SensorType;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.SensorTypes
{
    public class NewSensorType : EFBaseUseCase, INewSensorType
    {
        private readonly NewSensorTypeValidator _validator;
        public NewSensorType(CameraShopDbContext context, NewSensorTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.NewSensorTypeUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.NewSensorTypeUseCase);

        public string Description => "New Sensor type";

        public void Execute(NewSensorTypeDto request)
        {
            this._validator.ValidateAndThrow(request);

            var newSensorType = new SensorType()
            {
                Type = request.Name
            };

            this._context.SensorTypes.Add(newSensorType);
        }
    }
}
