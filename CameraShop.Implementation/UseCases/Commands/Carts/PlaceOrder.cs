using CameraShop.Application.Core;
using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.CartUseCases;
using CameraShop.Domain;
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
    public class PlaceOrder : EFBaseUseCase, IPlaceOrder
    {
        private readonly PlaceOrderValidator _validator;
        private readonly IApplicationUser _user;
        public PlaceOrder(CameraShopDbContext context, PlaceOrderValidator validator, IApplicationUser user) : base(context)
        {
            _validator = validator;
            _user = user;
        }

        public int Id => (int)UseCaseEnum.PlaceOrderUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.PlaceOrderUseCase);

        public string Description => "Moves a cart to order";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var cartToMove = this._context.Carts.Find(request.Id);

            var itemLists = this._context.CartItems.Where(x => x.CartId == request.Id).Select(x => new helperInnerClass()
            {
                CameraId = x.CameraId,
                Price = x.Camera.Price,
                Quantity = x.Quantity,
                DiscountPercentage = x.Camera.Discounts.Where(x => x.EndDate > DateTime.UtcNow).Select(x => x).FirstOrDefault().DiscountPercentage
            }).ToList();

            decimal amountOfMoney = 0;

            foreach (var item in itemLists)
            {
                decimal moneyPlus = 0;

                var cameraPrice = item.DiscountPercentage == null ? item.Price : item.Price - item.Price * (decimal)item.DiscountPercentage / 100;

                moneyPlus = item.Quantity < 0 ? 0 : item.Quantity * cameraPrice;

                amountOfMoney += moneyPlus;
            }

            var newOrder = new Order()
            {
                CartId = request.Id,
                UserId = this._user.Id,
                TotalAmount = amountOfMoney,
                IsOrderComplete = false
            };

            cartToMove.IsActive = false;

            this._context.Orders.Add(newOrder);
            this._context.SaveChanges();
        }
        private class helperInnerClass
        {
            public int CameraId { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public decimal? DiscountPercentage { get; set; }
        }
    }
}
