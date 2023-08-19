using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.BrandDto
{
    public class UpdateBrandDto : DtoBase
    {
        public int IdOfObject { get; set; }
        public string Name { get; set; }
    }
}
