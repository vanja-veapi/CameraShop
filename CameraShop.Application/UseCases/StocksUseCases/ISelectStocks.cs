using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches.StockSearches;
using CameraShop.Application.Dto.StockDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.StocksUseCases
{
    public interface ISelectStocks : IQuery<DtoListReturn<StockDto>, StockSearch>
    {
    }
}
