using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Domain
{
    public class StockPlace : Entity
    {
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal latitude { get; set; }

        public IEnumerable<Stock> Stocks { get; set; }
    }
}
