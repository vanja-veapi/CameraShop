using CameraShop.Application.Dto.Logging;

namespace CameraShop.Application.Core.Logging
{
    public interface IUseCaseLogger
    {
        void UseCaseLog(UseCaseLogDto log);
    }
}
