using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.CartDto
{
    public class ViewCartDto : DtoBase
    {
        public int CartId { get; set; }
        public List<Item> Items { get; set; }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
    }
}
