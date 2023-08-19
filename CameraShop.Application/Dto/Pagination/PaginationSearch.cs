using CameraShop.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Pagination
{
    public class PaginationSearch : BaseSearch
    {
        public int PerPage { get; set; } = 6;
        public int Page { get; set; } = 1;
    }
}
