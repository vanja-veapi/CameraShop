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
    public class RemoveCameraDiscount : EFBaseUseCase, IRemoveCameraDiscount
    {
        private readonly RemoveCameraDiscountValidator _validator;
        public RemoveCameraDiscount(CameraShopDbContext context, RemoveCameraDiscountValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveCameraDiscountUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveCameraDiscountUseCase);

        public string Description => "Removes a discount";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var discountToRemove = this._context.Discounts.Find(request.Id);

            discountToRemove.IsActive = false;

            this._context.SaveChanges();
        }
    }
}
