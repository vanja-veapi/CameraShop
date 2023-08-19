using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.UseCases.BrandUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Brand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Brands
{
    public class UpdateCameraBrand : EFBaseUseCase, IUpdateCameraBrand
    {
        private readonly UpdateCameraBrandValidator _validator;
        public UpdateCameraBrand(CameraShopDbContext context, UpdateCameraBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.UpdateBrandUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UpdateBrandUseCase);

        public string Description => "Update a brand";

        public void Execute(UpdateBrandDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToChange = this._context.Brands.Find(request.IdOfObject);

            objectToChange.BrandName = request.Name;

            this._context.SaveChanges();
        }
    }
}
