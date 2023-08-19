using CameraShop.Application.Dto.CartDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.CartUseCases
{
    public interface IRemoveitemFromCart : ICommand<RemoveItemFromCartDto>
    {
    }
}
