using CameraShop.Application.Dto;
using CameraShop.Application.UseCases;

namespace CameraShop.Application.UseCases.UseCaseHandlers
{
    public interface ICommandHandler
    {
        void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
            where TRequest : DtoBase;
    }
}
