using CameraShop.Application.Dto;
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
    public class ActivateUserAccount : EFBaseUseCase, IActivateUserAccount
    {
        private readonly ActivateUserAccountValidator _validator;
        public ActivateUserAccount(CameraShopDbContext context, ActivateUserAccountValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.ActivateUserAccountUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.ActivateUserAccountUseCase);

        public string Description => "Activating the account of a user";

        public void Execute(UserActivisionLinkDto request)
        {
            this._validator.ValidateAndThrow(request);

            var userToActivate = this._context.Users.Where(x => x.UniqueActivisonCode == request.ActivisionId).Select(x => x).FirstOrDefault();

            if(userToActivate == null)
            {
                return;
            }
            else if (userToActivate.IsAccountActivated)
            {
                return;
            }
            else
            {
                userToActivate.IsAccountActivated = true;
            }
            this._context.SaveChanges();
        }
    }
}
