using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace AbcloudzWebAPI.ErrorHandling
{
    public class AbcloudzExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<AbcloudzExceptionHandler> logger;
        public AbcloudzExceptionHandler(ILogger<AbcloudzExceptionHandler> logger)
        {
            this.logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            httpContext.Response.ContentType = Application.ProblemJson;
            var problemDetails = new ProblemDetails();
            switch (exception)
            {
                case FluentValidation.ValidationException:
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                        problemDetails.Status = StatusCodes.Status400BadRequest;
                        problemDetails.Detail = exception.Message;
                        break;
                    }
                default:
                    {
                        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        problemDetails.Status = StatusCodes.Status500InternalServerError;
                        problemDetails.Detail = "Internal Server Error";
                        break;
                    }
            }

            await httpContext.Response.WriteAsJsonAsync(problemDetails);

            var exceptionMessage = exception.Message;
            logger.LogError(
                "Error Message: {exceptionMessage}, Time of occurrence {time}",
                exceptionMessage, DateTime.UtcNow);

            return await ValueTask.FromResult(true);
        }
    }
}
