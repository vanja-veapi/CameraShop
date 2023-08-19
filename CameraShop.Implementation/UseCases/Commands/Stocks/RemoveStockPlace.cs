using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Stock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Stocks
{
    public class RemoveStockPlace : EFBaseUseCase, IRemoveStockPlace
    {
        private readonly RemoveStockPlaceValidator _validator;
        public RemoveStockPlace(CameraShopDbContext context, RemoveStockPlaceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveStockPlaceUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveStockPlaceUseCase);

        public string Description =>"Removes a stock palce";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToRemove = this._context.StockPlaces.Find(request.Id);

            this._context.StockPlaces.Remove(objectToRemove);

            this._context.SaveChanges();
        }
    }
}
