using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.StockDto
{
    public class NewStockPlaceDto : DtoBase
    {
        public string StockName { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public List<InStocks> inStocks { get; set; }
    }

    public class InStocks
    {
        public int IdCamera { get; set; }
        public int Quantity { get; set; }
    }
}
