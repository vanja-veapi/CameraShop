using CameraShop.Application.Dto.CartDto;
using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.CartUseCases
{
    public interface IViewCart : IQuery<DtoPaginationResponse<ViewCartDto>, EmptySearch>
    {
    }
}
