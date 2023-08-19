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
    public class NewStockPlace : EFBaseUseCase, INewStockPlace
    {
        private readonly NewStockPlaceValidator _validator;
        public NewStockPlace(CameraShopDbContext context, NewStockPlaceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.NewStockPlaceUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.NewStockPlaceUseCase);

        public string Description => "New Stock place with stocks if it has any";

        public void Execute(NewStockPlaceDto request)
        {
            this._validator.ValidateAndThrow(request);

            var newStock = new StockPlace()
            {
                Name = request.StockName,
                Longitude = request.Longitude,
                latitude = request.Latitude
            };

            if (request.inStocks.Count() > 0)
            {
                var listOfStocks = new List<Stock>();
                foreach (var item in request.inStocks)
                {
                    listOfStocks.Add(new Stock()
                    {
                        CameraId = item.IdCamera,
                        Quantity = item.Quantity
                    });
                }
                newStock.Stocks = listOfStocks;
            }

            this._context.StockPlaces.Add(newStock);

            this._context.SaveChanges();
        }
    }
}
