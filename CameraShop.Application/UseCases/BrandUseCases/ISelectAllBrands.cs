using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.BrandUseCases
{
    public interface ISelectAllBrands : IQuery<DtoListReturn<BrandsDto>, BasicSearch>
    {
    }
}
