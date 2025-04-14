using WebApiTemplate.Exceptions;

namespace WebApiTemplate.Middlewares;

public class ExceptionProcessor : IGlobalPostProcessor
{
    public async Task PostProcessAsync(IPostProcessorContext ctx, CancellationToken ct) {
        if (!ctx.HasExceptionOccurred)
            return;

        var exception = ctx.ExceptionDispatchInfo.SourceException;
        
        var stausCode = exception switch {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        ctx.MarkExceptionAsHandled();
        await ctx.HttpContext.Response.SendAsync(exception.Message, stausCode, cancellation: ct);
    }
}
