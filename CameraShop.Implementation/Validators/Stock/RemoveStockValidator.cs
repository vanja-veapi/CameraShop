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
    public class RemoveStockValidator : AbstractValidator<IdOnlyDto>
    {
        public RemoveStockValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id is mandatory").Must(x => context.Stocks.Any(y => y.Id == x)).WithMessage("Id does not exist");
        }
    }
}
