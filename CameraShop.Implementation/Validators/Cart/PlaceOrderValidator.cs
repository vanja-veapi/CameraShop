using CameraShop.Application.Core;
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
    public class PlaceOrderValidator : AbstractValidator<IdOnlyDto>
    {
        public PlaceOrderValidator(CameraShopDbContext context, IApplicationUser user)
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Cart id is mandatory").Must(x => context.Carts.Where(y=> y.UserId == user.Id).Any(y => y.Id == x)).WithMessage("Cart id not found");
        }
    }
}
