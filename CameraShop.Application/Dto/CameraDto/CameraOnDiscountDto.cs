using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.CameraDto
{
    public class CameraOnDiscountDto : DtoBase
    {
        public int IdCamera { get; set; }
        public double DiscountPercentage { get; set; }
        public DateTime StartsOn { get; set; }
        public DateTime EndsOn { get; set; }
    }
}
