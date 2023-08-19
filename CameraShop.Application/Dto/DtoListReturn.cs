using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto
{
    public class DtoListReturn<T> : DtoBase
        where T : DtoBase
    {
        public List<T> ListOfItems { get; set; }
    }
}
