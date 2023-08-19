using CameraShop.Application.Core;
using CameraShop.Application.Dto.CameraDto;
using CameraShop.Application.UseCases.CameraUseCases;
using CameraShop.Domain;
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
    public class NewCamera : EFBaseUseCase, INewCamera
    {
        private readonly NewCameraValidator _validator;
        private readonly IPictureMenager _pictureMenager;

        public NewCamera(CameraShopDbContext context, NewCameraValidator validator, IPictureMenager pictureMenager) : base(context)
        {
            _validator = validator;
            _pictureMenager = pictureMenager;
        }


        public int Id => (int)UseCaseEnum.NewCameraUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.NewCameraUseCase);

        public string Description => "Registers new camera to the application";

        public void Execute(NewCameraDto request)
        {
            this._validator.ValidateAndThrow(request);
            Domain.Discount newDiscount = null;

            var newCamera = new Camera()
            {
                Name = request.Name,
                BluetoothSupport = request.BlueThoothSupport,
                BrandId = request.BrandId,
                Description = request.Description,
                Megapixels = request.MegaPixels,
                ISO = request.ISO,
                VideoResolution = request.VideoResolution,
                WifiSupport = request.WifiSupport,
                LensMount = request.LensMount,
                Price = request.Price,
                SensorTypeId = request.SensorTypeId
            };

            if(request.Discount.StartDate != null && request.Discount.EndDate != null && request.Discount.DiscountPercentage != null)
            {
                newDiscount = new CameraShop.Domain.Discount()
                {
                    DiscountPercentage = (int)request.Discount.DiscountPercentage,
                    EndDate = (DateTime)request.Discount.EndDate,
                    StartDate = (DateTime)request.Discount.StartDate,
                    Camera = newCamera
                };
            }

            var listOfPictures = new List<CameraImage>();

            for (int i = 0; i < request.Pictures.Count(); i++)
            {
                var path = this._pictureMenager.movePicture(request.Pictures[i]);

                listOfPictures.Add(new CameraImage()
                {
                    ImagePath = path,
                    IsPrimary = request.indexOfPrimary == i,
                    Camera = newCamera
                });
            }

            this._context.Cameras.Add(newCamera);
            this._context.CameraImages.AddRange(listOfPictures);


            if(newDiscount != null)
            {
                this._context.Discounts.Add(newDiscount);
            }

            this._context.SaveChanges();

        }
    }
}
