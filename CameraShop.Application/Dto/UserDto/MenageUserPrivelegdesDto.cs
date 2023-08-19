using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.UserDto
{
    public class MenageUserPrivelegdesDto :DtoBase
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }
    }
}
