using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.Domain;
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
    public class PlaceStock : EFBaseUseCase, IPlaceStocks
    {
        private readonly PlaceStockValidator _validator;
        public PlaceStock(CameraShopDbContext context, PlaceStockValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.PlaceStockUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.PlaceStockUseCase);

        public string Description =>"Creates a new stock for a stock place";

        public void Execute(PlaceInStockDto request)
        {
            this._validator.ValidateAndThrow(request);

            if(request.InStocks.Count > 0)
            {
                var listOfStocks = new List<Stock>();
                foreach (var item in request.InStocks)
                {
                    listOfStocks.Add(new Stock()
                    {
                        CameraId = item.IdCamera,
                        Quantity = item.Quantity,
                        StockPlaceId = request.IdStockPlace
                    });
                }

                this._context.Stocks.AddRange(listOfStocks);

                this._context.SaveChanges();
            }
        }
    }
}
