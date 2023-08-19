using CameraShop.Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.UserDto
{
    public class UserSelectionDto: DtoBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<UserPriviledgdesDto> Priviledgdes { get; set; }
    }
    public class UserPriviledgdesDto : DtoBase 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UseCaseIdentifier { get; set; }
    }

}
