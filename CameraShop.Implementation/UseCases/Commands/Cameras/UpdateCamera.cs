using CameraShop.Application.Dto.CameraDto;
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
    public class UpdateCamera : EFBaseUseCase, IUpdateCamera
    {
        private readonly UpdateCameraValidator _validator;
        public UpdateCamera(CameraShopDbContext context, UpdateCameraValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.UpdateCameraUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UpdateCameraUseCase);

        public string Description => "Updates the camera";

        public void Execute(UpdateCameraDto request)
        {
            this._validator.ValidateAndThrow(request);

            var cameraToChange = this._context.Cameras.Find(request.CameraId);

            if (request.Name != null)
            {
                cameraToChange.Name = request.Name;
            }
            if (request.Description != null)
            {
                cameraToChange.Description = request.Description;
            }
            if (request.MegaPixels != null)
            {
                cameraToChange.Megapixels = (double)request.MegaPixels;
            }
            if (request.VideoResolution != null)
            {
                cameraToChange.VideoResolution = request.VideoResolution;
            }
            if (request.WifiSupport != null)
            {
                cameraToChange.WifiSupport = (bool)request.WifiSupport;
            }
            if (request.BluetoothSupport != null)
            {
                cameraToChange.BluetoothSupport = (bool)request.BluetoothSupport;
            }
            if (request.LensMount != null)
            {
                cameraToChange.LensMount = (bool)request.LensMount;
            }
            if (request.Price != null)
            {
                cameraToChange.Price = (decimal)request.Price;
            }
            if (request.SensorTypeId != null)
            {
                cameraToChange.SensorTypeId = (int)request.SensorTypeId;
            }
            if (request.BrandId != null)
            {
                cameraToChange.BrandId = (int)request.BrandId;
            }
            if (request.ISO != null)
            {
                cameraToChange.ISO = request.ISO;
            }

            this._context.SaveChanges();

        }
    }
}
