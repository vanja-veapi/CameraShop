using CameraShop.Application.Core;
using CameraShop.Application.Dto.CartDto;
using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.Carts
{
    public class ViewCart : EFBaseUseCase, IViewCart
    {
        private readonly IApplicationUser _user;
        public ViewCart(CameraShopDbContext context, IApplicationUser user) : base(context)
        {
            _user = user;
        }

        public int Id => (int)UseCaseEnum.SelectStockUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.SelectStockUseCase);

        public string Description => "View's the current cart";

        public DtoPaginationResponse<ViewCartDto> Execute(EmptySearch search)
        {
            var query = this._context.Carts.AsQueryable();
            query = query.Where(x => x.UserId == this._user.Id);

            return new DtoPaginationResponse<ViewCartDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new ViewCartDto()
                {
                    CartId = x.Id,
                    Items = x.CartItems.Select(y => new Item()
                    {
                        ItemId = y.Id,
                        Name = y.Camera.Name,
                        Quantity = y.Quantity,
                        ShortDescription = y.Camera.Description.Length > 30 ? y.Camera.Description.Substring(0, 30) + "..." : y.Camera.Description
                    }).ToList()
                }).ToList()
            };

        }
    }
}
