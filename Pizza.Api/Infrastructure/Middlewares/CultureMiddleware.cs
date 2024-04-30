using System.Globalization;

namespace Pizza.Api.Infrastructure.Middlewares;

public class CultureMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var defaultCultrueName = "ka-GE";
        CultureInfo.CurrentUICulture = new CultureInfo(defaultCultrueName);
        string cultureName = context.Request.Query["culture"];
        if (!string.IsNullOrEmpty(cultureName) && cultureName == "en-Us")
            CultureInfo.CurrentUICulture = new CultureInfo(cultureName);
        
        await next(context);
         
    }
}
