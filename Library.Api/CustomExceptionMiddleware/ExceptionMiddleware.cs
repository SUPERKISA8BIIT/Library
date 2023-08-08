using Library.BLL.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.CustomExceptionMiddleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IExceptionsService _exceptionService;

    public ExceptionMiddleware(RequestDelegate next, IExceptionsService exceptionService)
    {
        _next = next;
        _exceptionService = exceptionService;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.StatusCode = (int)_exceptionService.GetStatusCodeAndMessageOnException(exception);
        var message = exception switch
        {
            BusinessLogicEcxeption => exception.Message,
            _ => "Internal Server Error",
        };

        await context.Response.WriteAsJsonAsync(new ProblemDetails()
        {
            Status = context.Response.StatusCode,
            Detail = message,
            Type = $"https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/{context.Response.StatusCode}",
            Title =exception.GetType().Name,
            Instance = context.Request.Path
        });
    }
}
