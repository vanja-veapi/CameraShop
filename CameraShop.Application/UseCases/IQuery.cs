using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;

namespace CameraShop.Application.UseCases
{
    public interface IQuery<TResult, TRequest> : IUseCase
        where TResult : DtoBase
        where TRequest : BaseSearch
    {
        public TResult Execute(TRequest search);
    }
}
