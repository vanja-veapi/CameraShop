using CameraShop.Application.Dto.SensorTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.SensorTypeUseCases
{
    public interface IUpdateSensorType : ICommand<UpdateSensorTypeDto>
    {
    }
}
