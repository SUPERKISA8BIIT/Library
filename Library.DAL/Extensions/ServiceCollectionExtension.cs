using Library.DAL.Interfaces;
using Library.DAL.Models;
using Library.DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DAL.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddDataAccessLayer(this IServiceCollection services, string connectionString)
    {
        services.AddServices();
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
        services.AddIdentity<User, IdentityRole<Guid>>().AddEntityFrameworkStores<DatabaseContext>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    private static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
