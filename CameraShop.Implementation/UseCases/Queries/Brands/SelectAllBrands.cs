using CameraShop.Application.Dto;
using CameraShop.Application.Dto.BrandDto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.UseCases.BrandUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.Brands
{
    public class SelectAllBrands : EFBaseUseCase, ISelectAllBrands
    {
        public SelectAllBrands(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.SelectAllBrandsUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectAllBrandsUseCase);

        public string Description => "Selects all the brands";

        public DtoListReturn<BrandsDto> Execute(BasicSearch search)
        {
            var query = this._context.Brands.AsQueryable();

            if(search.Id != null)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if(search.Name != null)
            {
                query = query.Where(x => x.BrandName.Contains(search.Name));
            }

            return new DtoListReturn<BrandsDto>()
            {
                ListOfItems = query.Select(x => new BrandsDto()
                {
                    Id = x.Id,
                    Name = x.BrandName
                }).ToList()
            };
        }
    }
}
