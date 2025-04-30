using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Core.Authentication.Repositories;
using Core.Gaming.Repositories;
using Infrastructure.Authentication.repositories;
using Infrastructure.Gaming.repositories;

namespace Infrastructure.SharedKernel.Extensions;
public static class InfrastructureServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationDbContext>(opt =>
            opt.UseSqlServer(config.GetConnectionString("DefaultConnection")),
            ServiceLifetime.Scoped);

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IGameRepository, GameRepository>();
        services.AddScoped<IOwnershipRepository, OwnershipRepository>();


        return services;
    }
}