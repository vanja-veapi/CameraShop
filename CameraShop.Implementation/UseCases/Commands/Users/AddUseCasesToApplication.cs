using CameraShop.Application.Dto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.Domain;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Commands.Users
{
    public class AddUseCasesToApplication : EFBaseUseCase, IAddUseCasesToApplication
    {
        public AddUseCasesToApplication(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.AddUseCaseToTheApplicationUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.AddUseCaseToTheApplicationUseCase);

        public string Description => "Adding use casses to the application from enumerator";

        public void Execute(EmptyDto request)
        {
            var listOfUseCases = new List<UseCase>();

            foreach (var item in Enum.GetValues(typeof(UseCaseEnum)))
            {
                listOfUseCases.Add(new UseCase()
                {
                    UseCaseNumber = (int)item,
                    Name = Enum.GetName(typeof(UseCaseEnum), (int)item)
                });
            }
            this._context.UseCases.AddRange(listOfUseCases);
            this._context.SaveChanges();
        }
    }
}
