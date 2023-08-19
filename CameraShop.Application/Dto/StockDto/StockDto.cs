using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.StockDto
{
    public class StockDto : DtoBase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int StockId { get; set; }
        public string StockPlaceName { get; set; }
        public decimal StockLongitude { get; set; }
        public decimal StockLatitude { get; set; }
    }
}
