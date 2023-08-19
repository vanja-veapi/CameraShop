using CameraShop.Application.Dto.StockDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Stock
{
    public class PlaceStockValidator : AbstractValidator<PlaceInStockDto>
    {
        public PlaceStockValidator(CameraShopDbContext context, InStockMiniValidator inStockValidator)
        {
            RuleFor(x => x.IdStockPlace).NotNull().WithMessage("Stock place must not be null").Must(x => context.StockPlaces.Any(y => y.Id == x)).WithMessage("Given id does not exist");

            RuleForEach(x => x.InStocks).SetValidator(inStockValidator);
        }
    }
}
