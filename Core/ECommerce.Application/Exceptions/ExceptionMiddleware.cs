using ECommerce.Domain.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError($"Throw an exception by user : {httpContext?.Connection?.RemoteIpAddress?.MapToIPv4()}, Exception Message : {ex.Message}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }


        private static Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)StatusCodes.Status500InternalServerError;

            if (exception.GetType() == typeof(ValidationException))
            {
                return httpContext.Response.WriteAsync(new FluentValidationErrors()
                {
                    Errors = ((ValidationException)exception).Errors.Select(x => x.ErrorMessage),
                    StatusCode = httpContext.Response.StatusCode,
                }.ToString());
            }

            return httpContext.Response.WriteAsync(new ExceptionModel()
            {
                Message = exception.Message,
                StatusCode = httpContext.Response.StatusCode
            }.ToString());

        }


    }
}
