using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.Stocks
{
    public class SelectStockPlaces : EFBaseUseCase, ISelectStockPlaces
    {
        public SelectStockPlaces(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.SelectStockPlacesUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectStockPlacesUseCase);

        public string Description => "Get the stock places with quantity of cameras in stock";

        public DtoListReturn<StockPlacesDto> Execute(StockPlaceSearch search)
        {
            var query = this._context.StockPlaces.AsQueryable();

            if(search.IdCamera != null)
            {
                query = query.Where(x => x.Stocks.Any(y => y.CameraId == search.IdCamera));
            }

            if(search.idStockPlace != null)
            {
                query = query.Where(x => x.Id == search.idStockPlace);
            }

            return new DtoListReturn<StockPlacesDto>()
            {
                ListOfItems = query.Select(x => new StockPlacesDto()
                {
                    IdStockPlace = x.Id,
                    Latitude = x.latitude,
                    Longitude = x.Longitude,
                    Name = x.Name,
                    StocksInPlaces = x.Stocks.Select(y => new StocksInPlace()
                    {
                        CameraDescription = y.Camera.Description,
                        CameraName = y.Camera.Name,
                        IdCamera = y.CameraId,
                        Price = y.Camera.Price,
                        Quantity = y.Quantity,
                        discount = y.Camera.Discounts.Where(m => m.EndDate > DateTime.UtcNow).First().DiscountPercentage
                    }).ToList()
                }).ToList()
            };
        }
    }
}
