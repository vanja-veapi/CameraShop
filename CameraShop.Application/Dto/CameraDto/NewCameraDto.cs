using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CameraShop.Application.Dto.CameraDto
{
    public class NewCameraDto : DtoBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double MegaPixels { get; set; }
        public string ISO { get; set; }
        public string VideoResolution { get; set; }
        public bool WifiSupport { get; set; }
        public bool BlueThoothSupport { get; set; }
        public bool LensMount { get; set; }
        public decimal Price { get; set; }
        public Discount? Discount { get; set; }
        public int BrandId { get; set; }
        public int SensorTypeId { get; set; }
        public List<IFormFile> Pictures { get; set; }
        public int indexOfPrimary { get; set; }

    }
    public class Discount : DtoBase
    {
        public int? DiscountId { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public DateTime? StartDate { get; set; } = DateTime.MinValue;
        public DateTime? EndDate { get; set; } = DateTime.MinValue;
    }
    
}
