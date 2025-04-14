using FastEndpoints.Swagger;
using WebApiTemplate.Middlewares;

namespace WebApiTemplate.Infrastructure;

public static class PipelineConfigurator
{
    public static void ConfigurePipeline(this WebApplication app) {
        if (app.Environment.IsDevelopment()) {
            app.UseSwaggerGen();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.UseFastEndpoints(c => {
            c.Endpoints.Configurator = ep => {
                ep.PostProcessor<ExceptionProcessor>(Order.After);
            };
            c.Endpoints.RoutePrefix = "api";
        });
    }
}
