using Microsoft.Extensions.DependencyInjection;
using Application.Authentication.Services;
using Application.Authentication.Contracts;
using Application.Gaming.Contracts;
using Application.Gaming.Services;

namespace Application.SharedKernel.Extensions;
public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUserAppService, UserAppService>();
        services.AddScoped<IAuthService, AuthService>(); 
        services.AddHttpClient<IRawgService, RawgService>();
        services.AddScoped<IGameImporterService, GameImporterService>();



        return services;
    }
}
