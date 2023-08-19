using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using CameraShop.Application.Exceptions;

namespace CameraShop.API.Core
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        public GlobalExceptionHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 422;

                var errors = ex.Errors.Select(x => new
                {
                    x.ErrorMessage,
                    x.PropertyName
                });

                await context.Response.WriteAsJsonAsync(errors);
            }

            catch (UnauthorizedAccessException ex)
            {
                context.Response.StatusCode = 401;
            }
            catch(NotImplementedException ex)
            {

            }
            catch (ForbiddenUseCaseExecutionException ex)
            {
                context.Response.StatusCode = 403;

                var errors = new { message = "You are not allowed to execute approach this endpoint" };

                await context.Response.WriteAsJsonAsync(errors);
            }
            catch (Exception ex)
            {
                Guid errorId = Guid.NewGuid();
              
                context.Response.StatusCode = 500;
                context.Response.ContentType = "application/json";
                var responseBody = new
                {
                    message = "There was an error, please contact support."
                };

                await context.Response.WriteAsJsonAsync(responseBody);
            }
        }
    }
}
