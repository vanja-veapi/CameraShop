using CameraShop.Application.Dto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Cart
{
    public class CompleteOrderValidator : AbstractValidator<IdOnlyDto>
    {
        public CompleteOrderValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id of order must not be null").Must(x => context.Orders.Any(y => y.Id == x)).WithMessage("Order id not found");
        }
    }
}
