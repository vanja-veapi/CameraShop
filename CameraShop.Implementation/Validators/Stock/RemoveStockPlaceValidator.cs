using CameraShop.Application.Dto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Stock
{
    public class RemoveStockPlaceValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveStockPlaceValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is mandatory").Must(x => context.StockPlaces.Any(y => y.Id == x)).WithMessage("Given id does not exist").Must(x => !context.Stocks.Any(y => y.StockPlaceId == x)).WithMessage("This stock place has active stocks - can not remove");
        }
    }
}
