using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.CameraUseCases;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Camera;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Cameras
{
    public class RemoveCamera : EFBaseUseCase, IRemoveCamera
    {
        private readonly RemoveCameraValidator _validator;

        public RemoveCamera(CameraShopDbContext context, RemoveCameraValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveCameraUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveCameraUseCase);

        public string Description => "Remove a camera";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var cameraToRemove = this._context.Cameras.Find(request.Id);

            this._context.Cameras.Remove(cameraToRemove);

            this._context.SaveChanges();
        }
    }
}
