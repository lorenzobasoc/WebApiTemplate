using WebApiTemplate.DataAccess;
using FastEndpoints.Swagger;
using WebApiTemplate.Repos;
using Microsoft.AspNetCore.Identity;

namespace WebApiTemplate.Infrastructure;

public static class ServicesConfigurator
{
    private static IServiceCollection _services;
    private static AppConfiguration _config;

    public static void ConfigureServices(this WebApplicationBuilder builder) {
        InitializeServices(builder);
        ConfigureDatabase();
        ConfigureAuthentication();
        ConfigureConfiguration();
        ConfigureRepos();
        ConfigureFastEndpoints();
    }

    private static void InitializeServices(WebApplicationBuilder builder) {
        _services = builder.Services;
        _config = new AppConfiguration(builder.Configuration);
    }

    private static void ConfigureRepos() {
        _services.AddTransient<ConfigurationRepo>();
    }

    private static void ConfigureConfiguration() {
        _services.AddSingleton(_config);
    }

    private static void ConfigureAuthentication() {
       _services.AddAuthorization();
        _services.AddAuthentication(options => {
            options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
        }).AddCookie(IdentityConstants.ApplicationScheme);
    }

    private static void ConfigureFastEndpoints() {
        _services.SwaggerDocument();
        _services.AddFastEndpoints();
    }

    private static void ConfigureDatabase() {
        var connString = _config.CONNECTION_STRING;
        _services.AddDbContext<Db>(
            options => options
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention(),
            contextLifetime: ServiceLifetime.Scoped);
    }
}
