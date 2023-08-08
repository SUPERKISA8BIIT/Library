using Library.Api.CustomExceptionMiddleware;

namespace Library.Api.Extensions;

public static class MiddlewareServiceCollectionExtension
{
    public static void AddExeptionService(this IServiceCollection services)
    {
        services.AddSingleton<IExceptionsService, ExceptionService>();
       
    }
}
