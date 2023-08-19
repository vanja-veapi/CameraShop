using CameraShop.Application.Dto.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Dto.Searches.User
{
    public class UserSearch : PaginationSearch
    {
        public string? FirstName { get; set; }
        public int? UserId { get; set; }
        public string? LastName { get; set; }
    }
}
