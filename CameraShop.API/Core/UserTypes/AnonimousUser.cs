using CameraShop.Application.Core;
using CameraShop.Domain;
using CameraShop.Implementation.UseCases;
using System.Collections.Generic;

namespace CameraShop.API.Core.UserTypes
{
    public class AnonimousUser : IApplicationUser
    {
        public int Id { get; set; } = -1;
        public string Identity { get; set; } = "Anonymous user";
        public string Email { get; set; } = "Anonymous email";
        public string Username { get; set; } = "Anonymous";
        public IEnumerable<int> UseCaseIds { get; set; } = new List<int>() 
        { 
            (int)UseCaseEnum.SelectStockUseCase, 
            (int)UseCaseEnum.SelectStockPlacesUseCase , 
            (int)UseCaseEnum.SelectAllBrandsUseCase , 
            (int)UseCaseEnum.SelectCamerasUseCase , 
            (int)UseCaseEnum.SelectSensorTypeUseCase , 
            (int)UseCaseEnum.CreateNewUserUseCase , 
            (int)UseCaseEnum.ActivateUserAccountUseCase,
            (int)UseCaseEnum.AddUseCaseToTheApplicationUseCase
        };
    }
}
