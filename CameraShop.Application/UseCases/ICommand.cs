using CameraShop.Application.Dto;

namespace CameraShop.Application.UseCases
{
    public interface ICommand<TRequest> : IUseCase
        where TRequest : DtoBase
    {
        void Execute(TRequest request);
    }
}
