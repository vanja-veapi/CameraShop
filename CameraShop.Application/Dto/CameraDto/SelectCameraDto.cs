using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.CameraDto
{
    public class SelectCameraDto : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double MegaPixels { get; set; }
        public string ISO { get; set; }
        public string VideoResolution { get; set; }
        public bool WifiSupport { get; set; }
        public bool BlueThoothSupport { get; set; }
        public bool LensMount { get; set; }
        public decimal Price { get; set; }

        public List<Stock> Stock { get; set; }
        public List<Image> Images { get; set; }
        public IdName Brand { get; set; }
        public IdName sensorType { get; set; }
        public Discount? Discount { get; set; }

    }

    public class IdName : DtoBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Image : DtoBase
    {
        public int ImageId { get; set; }
        public string ImagePath { get; set; }
        public bool IsPrimary { get; set; }
    }
    public class Stock :DtoBase
    {
        public int StockId { get; set; }
        public int StockPlaceId { get; set; }
        public int Quantity { get; set; }
        public string StockName { get; set; }
        public decimal Longitude  { get; set; }
        public decimal Latitude { get; set; }
    }
    
}
