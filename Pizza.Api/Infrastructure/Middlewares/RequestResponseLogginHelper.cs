using Serilog;
using Serilog.Context;

namespace Pizza.Api.Infrastructure.Middlewares
{
    public  class RequestResponseLogginHelper : IMiddleware
    {

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string clientIp = context.Connection.RemoteIpAddress?.ToString();
            LogContext.PushProperty("ClientIp", clientIp);
            await next(context);
        }
    }
}
