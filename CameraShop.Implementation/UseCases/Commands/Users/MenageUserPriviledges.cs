using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.Domain;
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
    public class MenageUserPriviledges : EFBaseUseCase, IMenageUserPriviledges
    {
        private readonly MenageUserPriviledgesValidator _validator;
        public MenageUserPriviledges(CameraShopDbContext context, MenageUserPriviledgesValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => (int)UseCaseEnum.MenageUserPriviledgesUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.MenageUserPriviledgesUseCase);

        public string Description => "Menages user priviledges, adding or removing them";

        public void Execute(MenageUserPrivelegdesDto request)
        {
            this._validator.ValidateAndThrow(request);

            var alreadyHasPriviledge = this._context.UserUseCases.Where(x => x.UseCaseId == request.UseCaseId && x.UserId == request.UserId).FirstOrDefault();

            if(alreadyHasPriviledge != null)
            {
                alreadyHasPriviledge.IsActive = false;
            }
            else
            {
                var newPriviledge = new UserUseCase()
                {
                    UserId = request.UserId,
                    UseCaseId = request.UseCaseId
                };
                this._context.UserUseCases.Add(newPriviledge);
            }

            this._context.SaveChanges();

        }
    }
}
