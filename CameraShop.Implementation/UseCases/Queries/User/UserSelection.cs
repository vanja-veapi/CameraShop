using CameraShop.Application.Dto.Pagination;
using CameraShop.Application.Dto.Searches.User;
using CameraShop.Application.Dto.UserDto;
using CameraShop.Application.UseCases.UserUseCases;
using CameraShop.EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.UseCases.Queries.User
{
    public class UserSelection : EFBaseUseCase, IUserSelection
    {
        public UserSelection(CameraShopDbContext context) : base(context)
        {
        }

        public int Id => (int)UseCaseEnum.UserSelectionUseCase;

        public string Name => Enum.GetName(typeof(UseCaseEnum), (int)UseCaseEnum.UserSelectionUseCase);

        public string Description => "Select's all the users and their priviledges";

        public DtoPaginationResponse<UserSelectionDto> Execute(UserSearch search)
        {
            var query = this._context.Users.AsQueryable();

            if (search.UserId != null)
            {
                query = query.Where(x => x.Id == search.UserId);
            }
            if (search.FirstName != null)
            {
                query = query.Where(x => x.FirstName == search.FirstName);
            }
            if (search.LastName != null)
            {
                query = query.Where(x => x.LastName == search.LastName);
            }

            query = query.Where(x => x.IsAccountActivated);
            return new DtoPaginationResponse<UserSelectionDto>()
            {
                CurrentPage = search.Page,
                PerPage = search.PerPage,
                TotalCount = query.Count(),
                Data = query.Skip((search.Page - 1) * search.PerPage).Take(search.PerPage).Select(x => new UserSelectionDto()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserId = x.Id,
                    Priviledgdes = x.UserUseCases.Select(y => new UserPriviledgdesDto()
                    {
                        Id = y.Id,
                        Name = y.UseCase.Name,
                        UseCaseIdentifier = y.UseCase.UseCaseNumber
                    }).ToList()
                }).ToList()
            };
        }
    }
}
