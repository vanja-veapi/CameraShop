using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.UseCaseHandlers
{
    public interface IUseCaseHandler : ICommandHandler, IQueryHandler
    {
    }
}
