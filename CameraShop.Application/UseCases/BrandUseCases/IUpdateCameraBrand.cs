using CameraShop.Application.Dto.BrandDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.BrandUseCases
{
    public interface IUpdateCameraBrand : ICommand<UpdateBrandDto>
    {
    }
}
