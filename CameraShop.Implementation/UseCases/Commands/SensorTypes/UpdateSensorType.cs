using CameraShop.Application.Dto.SensorTypeDto;
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
    public class UpdateSensorType : EFBaseUseCase, IUpdateSensorType
    {
        private readonly UpdateSensorTypeValidator _validator;
        public UpdateSensorType(CameraShopDbContext context, UpdateSensorTypeValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.UpdateSensorTypeUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UpdateSensorTypeUseCase);

        public string Description => "Update a sensor type";

        public void Execute(UpdateSensorTypeDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToUpdate = this._context.SensorTypes.Find(request.IdToUpdate);

            objectToUpdate.Type = request.Name;

            this._context.SaveChanges();
        }
    }
}
