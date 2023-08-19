using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.StockDto
{
    public class StockPlacesDto : DtoBase
    {
        public int IdStockPlace { get; set; }
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public List<StocksInPlace> StocksInPlaces { get; set; }
    }

    public class StocksInPlace : DtoBase
    {
        public int Quantity { get; set; }
        public int IdCamera { get; set; }
        public string CameraName { get; set; }
        public string CameraDescription { get; set; }
        public decimal Price { get; set; }
        public decimal? discount  { get; set; }

    }
}
