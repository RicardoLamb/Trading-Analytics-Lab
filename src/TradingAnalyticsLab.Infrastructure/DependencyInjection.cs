using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TradingAnalyticsLab.Application.Abstractions.Persistence;
using TradingAnalyticsLab.Infrastructure.Persistence;
using TradingAnalyticsLab.Infrastructure.Persistence.Repositories;

namespace TradingAnalyticsLab.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<TradingAnalyticsLabDbContext>(
            options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString(
                        "DefaultConnection"));
            });

        services.AddScoped<ITraderRepository, TraderRepository>();

        services.AddScoped<ITradingAccountRepository, TradingAccountRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}