using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.SensorTypeDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.SensorTypeUseCases
{
    public interface ISelectAllSensorType  : IQuery<DtoListReturn<SelectSensorType>,BasicSearch>
    {
    }
}
