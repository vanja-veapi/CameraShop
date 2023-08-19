using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraShop.Application.Core;
using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using CameraShop.Implementation.Validators.User;
using FluentValidation;

namespace CameraShop.Implementation.UseCases.Commands.Users
{
    public class CreateNewUser : EFBaseUseCase, ICreateNewUser
    {
        private readonly CreateNewUserValidator _validator;
        private readonly IStringEncryptor _encryptor;
        private readonly IEmailSender _emailSender;
        public CreateNewUser(CameraShopDbContext context, CreateNewUserValidator validator, IStringEncryptor encryptor, IEmailSender emailSender) : base(context)
        {
            _validator = validator;
            _encryptor = encryptor;
            _emailSender = emailSender;
        }

        public int Id => (int)UseCaseEnum.CreateNewUserUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.CreateNewUserUseCase);

        public string Description => "Creates a new user";

        public void Execute(NewUserDto request)
        {
            this._validator.ValidateAndThrow(request);

            var listOfUseCases = new List<UserUseCase>();

            var userDefaultAllowdUseCases = new List<int>();

            userDefaultAllowdUseCases.Add((int)UseCaseEnum.SelectStockPlacesUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.SelectStockUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.SelectSensorTypeUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.SelectCamerasUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.SelectAllBrandsUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.UpdateUserInfoUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.PutItemInCartUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.ViewCartUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.RemoveItemFromCartUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.PlaceOrderUseCase);
            userDefaultAllowdUseCases.Add((int)UseCaseEnum.CompleteOrderUseCase);

            var listOfUseCaseIds = this._context.UseCases.Where(x => userDefaultAllowdUseCases.Contains(x.UseCaseNumber)).Select(x => x.Id).ToList();

            var userUseCaseList = new List<UserUseCase>();
            foreach (var item in listOfUseCaseIds)
            {
                userUseCaseList.Add(new UserUseCase()
                {
                    UseCaseId = item
                });
            }
            var activisonLinkstring = this._encryptor.EncryptString(request.Password) + this._encryptor.EncryptString(request.Email);

            var newUser = new User()
            {
                UserName = request.Username,
                Password = this._encryptor.EncryptString(request.Password),
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                RoleId = this._context.Roles.Where(x=>x.Name.Contains("Regular")).First().Id,
                UserUseCases = userUseCaseList,
                UniqueActivisonCode = activisonLinkstring,
                IsAccountActivated = false
            };

            this._context.Users.Add(newUser);

            this._context.SaveChanges();

            var activationLink = "http://localhost:5001/api/User/ActivateUserAccount?ActivisionId=" + activisonLinkstring;

            //slanje imejla ne radi zbog googla, ali se moze izvuci iz baze link za aktivaciju  
            //this._emailSender.SendEmail("Activate account", request.Email, @"click the link to activate account : <a href='" + activationLink + "'> Link </a>");

        }
    }
}
