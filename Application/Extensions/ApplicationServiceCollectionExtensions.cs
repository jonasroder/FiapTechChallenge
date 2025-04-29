using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces;
using Application.Services;

namespace Application.Extensions;
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();

        return services;
    }
}
