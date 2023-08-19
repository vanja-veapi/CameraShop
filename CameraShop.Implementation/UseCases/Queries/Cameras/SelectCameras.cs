using CameraShop.Application.Dto.CameraDto;
using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches.CameraSearches;
using CameraShop.Application.UseCases.CameraUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.Cameras
{
    public class SelectCameras : EFBaseUseCase, ISelectCameras
    {
        public SelectCameras(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.SelectCamerasUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectCamerasUseCase);

        public string Description => "Selects all cameras";

        public DtoPaginationResponse<SelectCameraDto> Execute(CameraSearch search)
        {
            var query = this._context.Cameras.AsQueryable();

            if (search.Id != null)
            {
                query = query.Where(x => x.Id == search.Id);
            }
            if (search.Name != null)
            {
                query = query.Where(x => x.Name.Contains(search.Name));
            }
            if (search.MegaPixels != null)
            {
                query = query.Where(x => x.Megapixels == search.MegaPixels);
            }
            if (search.VideoResolution != null)
            {
                query = query.Where(x => x.VideoResolution == search.VideoResolution);
            }
            if (search.WifiSupport != null)
            {
                query = query.Where(x => x.WifiSupport == search.WifiSupport);
            }
            if (search.BluetoothSupport != null)
            {
                query = query.Where(x => x.BluetoothSupport == search.BluetoothSupport);
            }
            if (search.LensMount != null)
            {
                query = query.Where(x => x.LensMount == search.LensMount);
            }
            if (search.PriceRangeLower != null)
            {
                query = query.Where(x => x.Price >= search.PriceRangeLower);
            }
            if (search.PriceRangeUpper != null)
            {
                query = query.Where(x=>x.Price <= search.PriceRangeUpper); 
            }
            if (search.SensorTypeId != null)
            {
                query = query.Where(x => x.SensorTypeId == search.SensorTypeId);
            }
            if (search.BrandId != null)
            {
                query = query.Where(x => x.BrandId == search.BrandId);
            }
            if (search.StockPlaceId != null)
            {
                query = query.Where(x=>x.Stocks.Where(y => y.StockPlaceId == search.StockPlaceId).Any());
            }
            if (search.OnDiscount != null)
            {
                if ((bool)search.OnDiscount)
                {
                    query = query.Where(x => x.Discounts.Any(y => y.EndDate > DateTime.UtcNow));
                }
                else
                {
                    query = query.Where(x => !x.Discounts.Any(y => y.EndDate > DateTime.UtcNow));
                }
            }

            return new DtoPaginationResponse<SelectCameraDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new SelectCameraDto()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    MegaPixels = x.Megapixels,
                    ISO = x.ISO,
                    VideoResolution = x.VideoResolution,
                    WifiSupport = x.WifiSupport,
                    BlueThoothSupport = x.BluetoothSupport,
                    LensMount = x.LensMount,
                    Price = x.Price,
                    Brand = new IdName()
                    {
                        Id = x.Brand.Id,
                        Name = x.Brand.BrandName
                    },
                    sensorType = new IdName()
                    {
                        Id = x.SensorType.Id,
                        Name = x.SensorType.Type
                    },
                    Stock = x.Stocks.Select(y => new Stock()
                    {
                        StockId = y.Id,
                        StockPlaceId = y.StockPlace.Id,
                        Quantity = y.Quantity,
                        StockName = y.StockPlace.Name,
                        Latitude = y.StockPlace.latitude,
                        Longitude = y.StockPlace.Longitude

                    }).ToList(),
                    Images = x.CameraImages.Select(y => new Image()
                    {
                        ImageId = y.Id,
                        ImagePath = y.ImagePath,
                        IsPrimary = y.IsPrimary
                    }).ToList(),
                     Discount = x.Discounts.Where(y => y.EndDate > DateTime.UtcNow).Select(m => new Discount()
                    {
                        DiscountId = m.Id,
                        DiscountPercentage = m.DiscountPercentage,
                        EndDate = m.EndDate,
                        StartDate = m.StartDate
                    }).FirstOrDefault()
                }).ToList()
            };
        }
    }
}
