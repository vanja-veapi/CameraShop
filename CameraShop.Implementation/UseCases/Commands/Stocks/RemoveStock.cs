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
    public class RemoveStock : EFBaseUseCase, IRemoveStock
    {
        private readonly RemoveStockValidator _validator;
        public RemoveStock(CameraShopDbContext context, RemoveStockValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.RemoveStockUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveStockUseCase);

        public string Description => "Removes a stock from a stock place";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToRemove = this._context.Stocks.Find(request.Id);

            this._context.Stocks.Remove(objectToRemove);

            this._context.SaveChanges();
        }
    }
}
