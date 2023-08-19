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
    public class NewStockPlaceValidator : AbstractValidator<NewStockPlaceDto>
    {
        public NewStockPlaceValidator(CameraShopDbContext context, InStockMiniValidator inStockValidator)
        {
            RuleFor(x => x.StockName).NotEmpty().WithMessage("StockName must not be empty").Must(x => !context.StockPlaces.Any(y => y.Name == x)).WithMessage("StockName name already exists").Matches("^[A-Z][A-z1-9 ]{3,19}$").WithMessage("StockName must beggin with capital letter, min 4 and max 20 characters");

            RuleFor(x => x.Latitude).NotNull().WithMessage("Latitude is mandatory field");
            RuleFor(x => x.Longitude).NotNull().WithMessage("Longitude is mandatory field");
            RuleForEach(x => x.inStocks).SetValidator(inStockValidator);
        }
    }
    public class InStockMiniValidator : AbstractValidator<InStocks>
    {
        public InStockMiniValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.IdCamera).NotEmpty().WithMessage("Id camera is mandatory").Must(x => context.Cameras.Any(y => y.Id == x)).WithMessage("Camera id is not found");

            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity is mandatory").Must(x => x >= 0).WithMessage("Minimum value is 0");
        }
    }
}
