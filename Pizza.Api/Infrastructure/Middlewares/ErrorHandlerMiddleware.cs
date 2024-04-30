using Microsoft.Extensions.Options;
using Pizza.Api.Infrastructure.GlobalErrorHander;

namespace Pizza.Api.Infrastructure.Middlewares;

public class ErrorHandlerMiddleware : IMiddleware
{
    private readonly string _path;

    public ErrorHandlerMiddleware(IOptions<ErrorLogging> el)
    {
        _path = el.Value.Path;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            var problem = new GlobalErrorHandler(context, ex, _path);

            context.Response.Clear();
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
