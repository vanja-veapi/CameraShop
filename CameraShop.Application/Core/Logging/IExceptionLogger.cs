using CameraShop.Application.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.Core.Logging
{
    public interface IExceptionLogger
    {
        void ExceptionLog(Exception ex, IUseCase useCase, object objInput);
    }
}
