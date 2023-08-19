using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Logging
{
    public class UseCaseLogDto : DtoBase
    {
        public int UserId { get; set; }
        public int UseCaseIdentifier { get; set; }
        public string Data { get; set; }
        public int DurationTime { get; set; }
    }
}
