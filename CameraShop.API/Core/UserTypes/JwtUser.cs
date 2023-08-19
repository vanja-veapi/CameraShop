using CameraShop.Application.Core;
using System.Collections.Generic;

namespace CameraShop.API.Core.UserTypes
{
    public class JwtUser : IApplicationUser
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public IEnumerable<int> UseCaseIds { get; set; }
        public bool IsAccountActivated { get; set; }
    }
}
