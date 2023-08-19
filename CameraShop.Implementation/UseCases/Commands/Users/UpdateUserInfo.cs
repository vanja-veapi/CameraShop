using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Users
{
    public class UpdateUserInfo : EFBaseUseCase, IUpdateUserInfo
    {
        private readonly UpdateUserInfoValidator _validator;
        public UpdateUserInfo(CameraShopDbContext context, UpdateUserInfoValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.UpdateUserInfoUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UpdateUserInfoUseCase);

        public string Description => "Update the user info";

        public void Execute(UpdateUserDataDto request)
        {
            this._validator.ValidateAndThrow(request);

            var userToUpdate = this._context.Users.Find(request.UserId);

            if (request.FirstName != null)
            {
                userToUpdate.FirstName = request.FirstName;
            }
            if (request.LastName != null)
            {
                userToUpdate.LastName = request.LastName;
            }
            if (request.Address != null)
            {
                userToUpdate.Address = request.Address;
            }
            if (request.PhoneNumber != null)
            {
                userToUpdate.PhoneNumber = request.PhoneNumber;
            }

            this._context.SaveChanges();
        }
    }
}
