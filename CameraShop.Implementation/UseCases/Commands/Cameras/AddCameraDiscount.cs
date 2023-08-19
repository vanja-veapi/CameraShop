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
    public class AddCameraDiscount : EFBaseUseCase, IAddCameraDiscount
    {
        private readonly AddCameraDiscountValidator _validator;
        public AddCameraDiscount(CameraShopDbContext context, AddCameraDiscountValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.AddCameraDiscountUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.AddCameraDiscountUseCase);
        public string Description => "Camera discount addition";

        public void Execute(CameraOnDiscountDto request)
        {
            this._validator.ValidateAndThrow(request);

            var camera = this._context.Cameras.Find(request.IdCamera);

            var newDiscount = new Domain.Discount()
            {
                Camera = camera,
                DiscountPercentage = (decimal)request.DiscountPercentage,
                StartDate = request.StartsOn,
                EndDate = request.EndsOn
            };

            this._context.Discounts.Add(newDiscount);

            this._context.SaveChanges();
        }
    }
}
