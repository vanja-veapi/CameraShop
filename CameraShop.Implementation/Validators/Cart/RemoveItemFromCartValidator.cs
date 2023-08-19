using CameraShop.Application.Core;
using CameraShop.Application.Dto.CartDto;
using CameraShop.EfDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Validators.Cart
{
    public class RemoveItemFromCartValidator : AbstractValidator<RemoveItemFromCartDto>
    {
        public RemoveItemFromCartValidator(CameraShopDbContext context, IApplicationUser user)
        {
            RuleFor(x => x.ItemId).NotNull().WithMessage("Item id can not be empty").Must(x => context.CartItems.Where(m=> m.Cart.UserId == user.Id).Any(y => y.Id == x)).WithMessage("given Item id not found on this user");

            RuleFor(x => x.QuantityToRemove).NotNull().WithMessage("Quantity must not be empty");
        }
    }
}
