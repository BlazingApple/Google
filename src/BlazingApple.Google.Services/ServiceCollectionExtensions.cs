using BlazingApple.Google.Services.Reviews;
using GoogleApi.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazingApple.Google.Services;

/// <summary>Extensions for adding Google services to the <see cref="IServiceCollection" /></summary>
public static class ServiceCollectionExtensions
{
    /// <summary>Add services for getting and sending tweets, including error logs</summary>
    /// <param name="services">Collection where the service should be registered</param>
    /// <param name="configRoot">Configuration containing the "Twitter" section</param>
    /// <returns><paramref name="services" /> (fluent API)</returns>
    public static IServiceCollection AddBlazingAppleGoogle(this IServiceCollection services, IConfiguration configRoot)
    {
        IConfigurationSection config = configRoot.GetSection("BlazingApple:Google");
        services.Configure<GoogleSettings>(config);
        services.AddGoogleApiClients();
        services.AddSingleton<ReviewService>();
        return services;
    }

    /// <summary>Add services for getting and sending tweets, including error logs</summary>
    /// <param name="services">Collection where the service should be registered</param>
    /// <param name="apiKey">The Google Api Key</param>
    /// <returns><paramref name="services" /> (fluent API)</returns>
    public static IServiceCollection AddBlazingAppleGoogle(this IServiceCollection services, string apiKey)
    {
        services.Configure<GoogleSettings>(opt => opt.ApiKey = apiKey);
        services.AddGoogleApiClients();
        services.AddSingleton<ReviewService>();
        return services;
    }
}
