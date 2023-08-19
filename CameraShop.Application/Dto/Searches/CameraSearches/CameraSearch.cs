using CameraShop.Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Searches.CameraSearches
{
    public class CameraSearch : PaginationSearch
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public double? MegaPixels { get; set; }
        public string? VideoResolution { get; set; }
        public bool? WifiSupport { get; set; }
        public bool? BluetoothSupport { get; set; }
        public bool? LensMount { get; set; }
        public decimal? PriceRangeLower { get; set; }
        public decimal? PriceRangeUpper { get; set; }
        public int? SensorTypeId { get; set; }
        public int? BrandId { get; set; }
        public int? StockPlaceId { get; set; }
        public bool? OnDiscount { get; set; }
    }
}
