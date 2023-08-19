using CameraShop.Application.Dto.CameraDto;
using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches.CameraSearches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.CameraUseCases
{
    public interface ISelectCameras : IQuery<DtoPaginationResponse<SelectCameraDto>,CameraSearch>
    {
    }
}
