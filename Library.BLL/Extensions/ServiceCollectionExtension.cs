
using Library.BLL.Interfaces;
using Library.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Library.BLL.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddServices();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthService, AuthService>();
    }
}
