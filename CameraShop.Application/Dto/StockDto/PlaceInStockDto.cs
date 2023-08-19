using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.StockDto
{
    public class PlaceInStockDto : DtoBase
    {
        public int IdStockPlace { get; set; }
        public List<InStocks> InStocks { get; set; }
    }
}
