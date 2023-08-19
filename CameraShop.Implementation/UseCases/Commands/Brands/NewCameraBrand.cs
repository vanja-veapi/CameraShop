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
    public class NewCameraBrand : EFBaseUseCase, INewCameraBrand
    {
        private readonly NewCameraBrandValidator _validator;

        public NewCameraBrand(CameraShopDbContext context, NewCameraBrandValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.NewCameraBrandUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.NewCameraBrandUseCase);

        public string Description => "Adding new Camera brand to the application";

        public void Execute(NewCameraBrandDto request)
        {
            this._validator.ValidateAndThrow(request);

            var newBrand = new Brand()
            {
                BrandName = request.Name
            };

            this._context.Brands.Add(newBrand);
            this._context.SaveChanges();
        }
    }
}
