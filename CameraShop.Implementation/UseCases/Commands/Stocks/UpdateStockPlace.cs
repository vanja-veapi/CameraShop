using CameraShop.Application.Dto.StockDto;
using CameraShop.Application.UseCases.StocksUseCases;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.Stock;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Stocks
{
    public class UpdateStockPlace : EFBaseUseCase, IUpdateStockPlace
    {
        private readonly UpdateStockPlaceValidator _validator;
        public UpdateStockPlace(CameraShopDbContext context, UpdateStockPlaceValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.UpdateStockPlaceUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UpdateStockPlaceUseCase);

        public string Description => "Updates the stock place";

        public void Execute(UpdateStockPlaceDto request)
        {
            this._validator.ValidateAndThrow(request);

            var objectToUpdate = this._context.StockPlaces.Find(request.IdToUpdate);

            if (request.Name != null)
            {
                objectToUpdate.Name = request.Name;
            }
            if(request.Longitude != null)
            {
                objectToUpdate.Longitude = (decimal)request.Longitude;
            }
            if (request.Latitude != null)
            {
                objectToUpdate.latitude = (decimal)request.Latitude;
            }

            this._context.SaveChanges();
        }
    }
}
