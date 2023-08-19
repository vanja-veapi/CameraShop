using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.StockDto
{
    public class UpdateStockPlaceDto :DtoBase
    {
        public int IdToUpdate { get; set; }
        public string? Name { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

    }
}
