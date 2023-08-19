using CameraShop.Application.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.UserUseCases
{
    public interface IUpdateUserInfo : ICommand<UpdateUserDataDto>
    {
    }
}
