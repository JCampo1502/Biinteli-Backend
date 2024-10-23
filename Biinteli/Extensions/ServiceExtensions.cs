using AspNetCoreRateLimit;
using Bussines.Interfaces;
using DataAccess.Repositories;

namespace App.Extensions;

public static class ServiceExtensions
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork,UnitOfWork>();
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(opts => {
            opts.AddPolicy("CorsPolicy", policy => {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
        });
    }

    public static void ConfigureRateLimiting(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
        services.AddInMemoryRateLimiting();
        services.Configure<IpRateLimitOptions>(opts => {
            opts.EnableEndpointRateLimiting = true;
            opts.StackBlockedRequests = false;
            opts.HttpStatusCode = 429;
            opts.RealIpHeader = "X-Real-IP";
            opts.GeneralRules = [
                new(){
                    Endpoint = "*",
                    Period = "10s",
                    Limit = 3
                }
            ];
        });
    }
}
