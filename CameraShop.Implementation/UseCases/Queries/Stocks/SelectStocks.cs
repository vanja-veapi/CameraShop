using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.UseCases;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.Stocks
{
    public class SelectStocks : EFBaseUseCase, ISelectStocks
    {
        public int Id => (int)UseCaseEnum.SelectStockUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectStockUseCase);

        public string Description => "Selects the stocks using the search, if needed";

        public SelectStocks(CameraShopDbContext context) : base(context)
        {
        }

        public DtoListReturn<StockDto> Execute(StockSearch search)
        {
            var query = this._context.Stocks.AsQueryable();

            if (search.IdProduct != null)
            {
                query = query.Where(x => x.Camera.Id == search.IdProduct);
            }
            if (search.Quantity != null)
            {
                query = query.Where(x => x.Quantity == search.Quantity);
            }
            if (search.StockPlaceID != null)
            {
                query = query.Where(x => x.StockPlaceId == search.StockPlaceID);
            }

            return new DtoListReturn<StockDto>()
            {
                ListOfItems = query.Select(x => new StockDto()
                {
                    Id = x.Id,
                    Quantity = x.Quantity,
                    StockId = x.StockPlaceId,
                    StockLatitude = x.StockPlace.latitude,
                    StockLongitude = x.StockPlace.Longitude,
                    StockPlaceName = x.StockPlace.Name
                }).ToList()
            };
        }
    }
}
