using CameraShop.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.CartUseCases
{
    public interface IPlaceOrder : ICommand<IdOnlyDto>
    {
    }
}
