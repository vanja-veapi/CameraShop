using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.SensorTypeDto
{
    public class UpdateSensorTypeDto :DtoBase
    {
        public int IdToUpdate { get; set; }
        public string Name { get; set; }
    }
}
