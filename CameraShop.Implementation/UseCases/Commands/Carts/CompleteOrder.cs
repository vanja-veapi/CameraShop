using CameraShop.Application.Dto;
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
    public class CompleteOrder : EFBaseUseCase, ICompleteOrder
    {
        private readonly CompleteOrderValidator _validator;
        public CompleteOrder(CameraShopDbContext context, CompleteOrderValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.CompleteOrderUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.CompleteOrderUseCase);

        public string Description => "Completes an order";

        public void Execute(IdOnlyDto request)
        {
            this._validator.ValidateAndThrow(request);

            var orderToComplete = this._context.Orders.Find(request.Id);

            orderToComplete.IsOrderComplete = true;

            this._context.SaveChanges();
        }
    }
}
