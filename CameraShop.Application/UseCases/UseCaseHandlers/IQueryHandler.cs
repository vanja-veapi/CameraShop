using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Application.UseCases.UseCaseHandlers
{
    public interface IQueryHandler
    {
        TResult HandleQuery<TResult, TRequest>(IQuery<TResult, TRequest> query, TRequest search)
            where TResult : DtoBase
            where TRequest : BaseSearch;

    }
}
