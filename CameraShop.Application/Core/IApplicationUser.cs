using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Core
{
    public interface IApplicationUser
    {
        int Id { get; set; }
        string Identity { get; set; }
        string Email { get; set; }
        string Username { get; set; }
        IEnumerable<int> UseCaseIds { get; set; }
    }
}
