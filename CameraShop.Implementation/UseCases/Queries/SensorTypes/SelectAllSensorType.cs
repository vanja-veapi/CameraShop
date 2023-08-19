using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Dto.SensorTypeDto;
using CameraShop.Application.UseCases;
using CameraShop.Application.UseCases.SensorTypeUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.SensorTypes
{
    public class SelectAllSensorType : EFBaseUseCase, ISelectAllSensorType
    {
        public SelectAllSensorType(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.SelectSensorTypeUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectSensorTypeUseCase);

        public string Description => "Selects sensor types";

        public DtoListReturn<SelectSensorType> Execute(BasicSearch search)
        {
            var query = this._context.SensorTypes.AsQueryable();

            if(search.Id != null)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if(search.Name != null)
            {
                query = query.Where(x => x.Type.Contains(search.Name));
            }

            return new DtoListReturn<SelectSensorType>()
            {
                ListOfItems = query.Select(x => new SelectSensorType()
                {
                    Id = x.Id,
                    Name = x.Type
                }).ToList()
            };
        }
    }
}
