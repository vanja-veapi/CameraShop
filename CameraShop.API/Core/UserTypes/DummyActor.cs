using CameraShop.Application.Core;
using System.Collections.Generic;
using System.Linq;

namespace CameraShop.API.Core.UserTypes
{
    public class DummyActor : IApplicationUser
    {
        public int Id { get; set; } = 3;
        public string Identity { get; set; } = "Dummy";
        public string Email { get; set; } = "Dummy";
        public string Username { get; set; } = "Dummy";
        public IEnumerable<int> UseCaseIds { get; set; } = Enumerable.Range(1, 100);
    }
}
