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
    public class PutItemInCartValidator : AbstractValidator<IteminCartDto>
    {
        public PutItemInCartValidator(CameraShopDbContext context)
        {
            RuleFor(x => x.ItemId).NotEmpty().WithMessage("Item id is mandatory").Must(x => context.Cameras.Any(y => y.Id == x)).WithMessage("Camera id does not exist").Must( x=> context.Stocks.Where(y => y.CameraId == x).Any(y => y.Quantity > 0)).WithMessage("Selected camera has no stocks");

            RuleFor(x => x.Quantity).NotNull().WithMessage("Quantity is mandatory").Must(x => x > 0).WithMessage("Quantity must be larger number than 0").Must((x, y) => context.Stocks.Where((z) => z.CameraId == x.ItemId && z.Quantity >= y).Count() > 0).WithMessage("You selected more of cameras than there are in the stocks");
        }
    }
}
