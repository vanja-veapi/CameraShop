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
    public class RemoveBrand : EFBaseUseCase, IRemoveBrand
    {
        private readonly RemoveBrandValidator _validator;
        public RemoveBrand(CameraShopDbContext context, RemoveBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveCameraBrandUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveCameraBrandUseCase);

        public string Description => "Removes a brand from the application";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToRemove = this._context.Brands.Find(request.Id);

            this._context.Brands.Remove(objectToRemove);
            this._context.SaveChanges();
        }
    }
}
