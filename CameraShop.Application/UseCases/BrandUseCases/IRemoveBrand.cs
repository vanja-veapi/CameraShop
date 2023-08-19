using CameraShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.BrandUseCases
{
    public interface IRemoveBrand : ICommand<IdOnlyDto>
    {
    }
}
