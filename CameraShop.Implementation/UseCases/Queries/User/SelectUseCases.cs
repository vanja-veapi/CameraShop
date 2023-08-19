using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.User
{
    public class SelectUseCases : EFBaseUseCase, ISelectUseCases
    {
        public SelectUseCases(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.SelectUseCasesUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectUseCasesUseCase);

        public string Description => "Selects all the use casses";

        public DtoListReturn<SelectUseCasesDto> Execute(BasicSearch search)
        {
            var query = this._context.UseCases.AsQueryable();

            if(search.Id != null)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if(search.UseCaseIdentifier != null)
            {
                query = query.Where(x => x.UseCaseNumber == search.UseCaseIdentifier);
            }
            if(search.Name != null)
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }

            return new DtoListReturn<SelectUseCasesDto>()
            {
                ListOfItems = query.Select(x => new SelectUseCasesDto()
                {
                    Id = x.Id,
                    UseCaseIdentifier = x.UseCaseNumber,
                    UseCaseName = x.Name
                }).ToList()
            };
        }
    }
}
