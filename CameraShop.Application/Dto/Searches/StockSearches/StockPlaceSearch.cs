using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Searches.StockSearches
{
    public class StockPlaceSearch : BaseSearch
    {
        public int? IdCamera { get; set; }
        public int? idStockPlace { get; set; }
    }
}
