using BusinessLayer.Abstract;
using EntityLayer.ErrorModels;
using EntityLayer.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ApiLayer.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFound => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError

                        };

                        logger.LogError($"Something went wrong : {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            SatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,

                        }.ToString());

                    }
                });
            });
        }


    }
}
