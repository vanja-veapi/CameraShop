using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Searches.StockSearches
{
    public class StockSearch : BaseSearch
    {
        public int? IdProduct { get; set; }
        public int? Quantity { get; set; }
        public int? StockPlaceID { get; set; }
    }
}
