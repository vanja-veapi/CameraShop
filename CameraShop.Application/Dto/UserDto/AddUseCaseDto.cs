using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.UserDto
{
    public class AddUseCaseDto :DtoBase
    {
        public string Name { get; set; }
        public int UseCaseNumber { get; set; }
    }
}
