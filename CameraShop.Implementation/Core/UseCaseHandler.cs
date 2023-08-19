using CameraShop.Application.Core;
using CameraShop.Application.Core.Logging;
using CameraShop.Application.Dto;
using CameraShop.Application.Dto.Logging;
using CameraShop.Application.Dto.Searches;
using CameraShop.Application.Exceptions;
using CameraShop.Application.UseCases;
using CameraShop.Application.UseCases.UseCaseHandlers;
using CameraShop.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraShop.Implementation.Core
{
    public class UseCaseHandler : IUseCaseHandler
    {

        private IExceptionLogger _exceptionLogger;
        private IUseCaseLogger _useCaseLogger;
        private IApplicationUser _appUser;

        public UseCaseHandler(IExceptionLogger exceptionLogger, IUseCaseLogger useCaseLogger, IApplicationUser appUser)
        {
            _exceptionLogger = exceptionLogger;
            _useCaseLogger = useCaseLogger;
            _appUser = appUser;
        }

        public void HandleCommand<TRequest>(ICommand<TRequest> command, TRequest data)
            where TRequest : DtoBase
        {
            try
            {
                if (!_appUser.UseCaseIds.Contains(command.Id))
                {
                    throw new ForbiddenUseCaseExecutionException(command.Name, _appUser.Identity);
                }
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                command.Execute(data);

                stopwatch.Stop();

                if (this._appUser.Id != -1)
                {
                    var UseCaseLog = new UseCaseLogDto()
                    {
                        DurationTime = (int)stopwatch.ElapsedMilliseconds / 1000,
                        UseCaseIdentifier = command.Id,
                        UserId = this._appUser.Id,
                        Data = JsonConvert.SerializeObject(command)
                    };

                    this._useCaseLogger.UseCaseLog(UseCaseLog);
                }
            }
            catch (Exception ex)
            {
                this._exceptionLogger.ExceptionLog(ex, command, data);
                throw;
            }
        }

        public TResult HandleQuery<TResult, TRequest>(IQuery<TResult, TRequest> query, TRequest search)
            where TResult : DtoBase
            where TRequest : BaseSearch
        {
            try
            {
                if (!this._appUser.UseCaseIds.Contains(query.Id))
                {
                    throw new ForbiddenUseCaseExecutionException(query.Name, _appUser.Identity);
                }
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var resoult = query.Execute(search);

                stopwatch.Stop();

                if (this._appUser.Id != -1)
                {
                    var UseCaseLog = new UseCaseLogDto()
                    {
                        DurationTime = (int)stopwatch.ElapsedMilliseconds/1000,
                        UseCaseIdentifier = query.Id,
                        UserId = this._appUser.Id,
                        Data = JsonConvert.SerializeObject(search)
                    };

                this._useCaseLogger.UseCaseLog(UseCaseLog);
                }

                return resoult;
            }
            catch (Exception ex)
            {
                this._exceptionLogger.ExceptionLog(ex, query, search);
                throw;
            }
        }


    }
}
