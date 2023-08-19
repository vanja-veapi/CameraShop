using CameraShop.Application.Dto.CameraDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.CameraUseCases
{
    public interface INewCamera : ICommand<NewCameraDto>
    {
    }
}
