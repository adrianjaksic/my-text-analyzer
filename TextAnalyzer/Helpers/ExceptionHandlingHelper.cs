using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using TextAnalyzer.Entities;
using TextAnalyzer.Entities.Exceptions;

namespace TextAnalyzer.Helpers
{
    public static class ExceptionHandlingHelper
    {
        public static IApplicationBuilder RegisterExceptionHandling(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var errorCode = ErrorCodeEnum.ServerError;
                        var ex = error.Error;
                        if (ex is BaseException be)
                        {
                            errorCode = be.ErrorCode;
                        }
                        logger.LogError(ex, context.Request.Path + context.Request.QueryString);
                        await context.Response.WriteAsync(JsonSerializer.Serialize(new BaseResponse()
                        {
                            ErrorCode = errorCode,
                            ErrorMessage = ex.Message
                        }));
                    }
                });
            });
            return app;
        }
    }
}
