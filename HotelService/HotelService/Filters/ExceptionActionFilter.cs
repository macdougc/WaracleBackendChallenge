using HotelService.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelService.Filters;

public class ExceptionActionFilter(ILogger<ExceptionActionFilter> logger) : IActionFilter
{
    private static readonly Dictionary<Type, int> ExceptionStatusCodes = new()
    {
        { typeof(NotFoundException), StatusCodes.Status404NotFound },
    };

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        Exception? exception = context.Exception;

        if (exception == null)
        {
            return;
        }

        int statusCode = GetStatusCodeForException(exception);

        context.Result = new ObjectResult(exception.Message)
        {
            StatusCode = statusCode
        };

        if (statusCode == StatusCodes.Status500InternalServerError)
        {
            logger.LogError(exception, "Message: {Message}", exception.Message);
        }

        context.ExceptionHandled = true;
    }

    private static int GetStatusCodeForException(Exception exception)
        => ExceptionStatusCodes.TryGetValue(exception.GetType(), out int statusCode) ? statusCode : StatusCodes.Status500InternalServerError;
}
