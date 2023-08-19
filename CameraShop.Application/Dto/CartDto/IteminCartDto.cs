using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.CartDto
{
    public class IteminCartDto : DtoBase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
