using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.SensorTypeUseCases;
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
    public class RemoveSensorType : EFBaseUseCase, IRemoveSensorType
    {
        private readonly RemoveSensorTypeValidator _validator;
        public RemoveSensorType(CameraShopDbContext context, RemoveSensorTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveSensorTypeUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveSensorTypeUseCase);

        public string Description => "Removes the sensor type";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var sensorTypeToRemove = this._context.SensorTypes.Find(request.Id);

            this._context.SensorTypes.Remove(sensorTypeToRemove);

            this._context.SaveChanges();
        }
    }
}
