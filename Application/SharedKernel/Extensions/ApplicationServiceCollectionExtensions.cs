using Microsoft.Extensions.DependencyInjection;
using Application.Authentication.Services;
using Application.Authentication.Interfaces;

namespace Application.SharedKernel.Extensions;
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IAuthService, AuthService>();

        return services;
    }
}
