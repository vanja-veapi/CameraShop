using CameraShop.Application.Core;
using CameraShop.Application.Dto.CartDto;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Cart;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Carts
{
    public class RemoveitemFromCart : EFBaseUseCase, IRemoveitemFromCart
    {
        private readonly RemoveItemFromCartValidator _validator;
        private readonly IApplicationUser _user;
        public RemoveitemFromCart(CameraShopDbContext context, RemoveItemFromCartValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }

        public int Id => (int)UseCaseEnum.RemoveItemFromCartUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.RemoveItemFromCartUseCase);

        public string Description => "Reduces, or completly removes an item from cart";

        public void Execute(RemoveItemFromCartDto request)
        {
            this._validator.ValidateAndThrow(request);

            var cartItemToChange = this._context.CartItems.Find(request.ItemId);

            if (cartItemToChange.Quantity - request.QuantityToRemove < 1)
            {
                cartItemToChange.IsActive = false;
            }
            else
            {
                cartItemToChange.Quantity -= request.QuantityToRemove;  
            }

            this._context.SaveChanges();

        }
    }
}
