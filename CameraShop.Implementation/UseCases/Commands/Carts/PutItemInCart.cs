using CameraShop.Application.Core;
using CameraShop.Application.Dto.CartDto;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Cart;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Carts
{
    public class PutItemInCart : EFBaseUseCase, IPutItemInCart
    {
        private readonly PutItemInCartValidator _validator;
        private readonly IApplicationUser _user;
        public PutItemInCart(CameraShopDbContext context, PutItemInCartValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }

        public int Id => (int)UseCaseEnum.PutItemInCartUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.PutItemInCartUseCase);

        public string Description => "Puts an item in the cart";

        public void Execute(IteminCartDto request)
        {
            this._validator.ValidateAndThrow(request);

            if(this._context.Carts.Any(x=>x.UserId == this._user.Id))
            {
                var cart = this._context.Carts.Include(x=>x.CartItems).Where(x => x.UserId == this._user.Id).Select(x => x).FirstOrDefault();

                if(cart.CartItems.Where(x => x.CameraId == request.ItemId).Count() <= 0)
                {
                    var newCartItem = new CartItem()
                    {
                        CartId = cart.Id,
                        CameraId = request.ItemId,
                        Quantity = request.Quantity
                    };

                    this._context.CartItems.Add(newCartItem);
                }
                else 
                {
                    var toIncreaseQuantity = cart.CartItems.Where(x => x.CameraId == request.ItemId).Select(x => x).FirstOrDefault();

                    toIncreaseQuantity.Quantity += request.Quantity;
                }
            }
            else
            {
                var newCart = new Cart()
                {
                    UserId = this._user.Id,
                    ActiveCart = true,
                    MovedToOrder = false
                };
                var newCartItem = new CartItem()
                {
                    CameraId = request.ItemId,
                    Quantity = request.Quantity,
                    Cart = newCart
                };

                this._context.CartItems.Add(newCartItem);
            }

            this._context.SaveChanges();

        }
    }
}
