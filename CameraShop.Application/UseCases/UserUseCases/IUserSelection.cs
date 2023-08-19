
using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches.CameraSearches;
using CameraShop.Application.Dto.Searches.User;
using CameraShop.Application.Dto.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.UserUseCases
{
    public interface IUserSelection : IQuery<DtoPaginationResponse<UserSelectionDto>, UserSearch>
    {
    }
}
