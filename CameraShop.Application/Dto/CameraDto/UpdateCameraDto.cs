using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.CameraDto
{
    public class UpdateCameraDto :DtoBase
    {
        public int CameraId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? MegaPixels { get; set; }
        public string? VideoResolution { get; set; }
        public bool? WifiSupport { get; set; }
        public bool? BluetoothSupport { get; set; }
        public bool? LensMount { get; set; }
        public decimal? Price { get; set; }
        public int? SensorTypeId { get; set; }
        public int? BrandId { get; set; }
        public string? ISO { get; set; }
    }
}
