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
    public class UpdateStockPlaceValidator : AbstractValidator<UpdateStockPlaceDto>
    {
        public UpdateStockPlaceValidator(CameraShopDbContext context)
        {

            RuleFor(x => x.IdToUpdate).NotNull().WithMessage("Id is mandatory").Must(x => context.StockPlaces.Any(y => y.Id == x)).WithMessage("Id does not exist");

            RuleFor(x => x.Name).Must(x => !context.StockPlaces.Any(y => y.Name == x)).When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("StockName name already exists").Matches("^[A-Z][A-z1-9 ]{3,19}$").When(x => !string.IsNullOrEmpty(x.Name)).WithMessage("StockName must beggin with capital letter, min 4 and max 20 characters");
           
        }
    }
}
