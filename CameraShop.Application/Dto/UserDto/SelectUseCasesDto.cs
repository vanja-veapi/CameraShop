using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.UserDto
{
    public class SelectUseCasesDto : DtoBase
    {
        public int Id{ get; set; }
        public string UseCaseName { get; set; }
        public int UseCaseIdentifier { get; set; }
    }
}
