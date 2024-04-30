using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Pizza.Application.Exceptions;
using Pizza.Application.Localization;

namespace Pizza.Api.Infrastructure.GlobalErrorHander
{
    public class GlobalErrorHandler : ProblemDetails
    {
        public GlobalErrorHandler(HttpContext context, Exception ex, string path)
        {

            LogException(path, ex);
            Extensions["TraceId"] = context.TraceIdentifier;
            Instance = context.Request.Path;
            Detail = ex is CustomException ? ex.Message : ErrorMessages.SomthingWentWRong;
            HandleException((dynamic)ex);
        }

        void HandleException(Exception ex)
        {
            Title = ErrorMessages.SomthingWentWRong;
            Status = StatusCodes.Status500InternalServerError;
            Type = @"https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1";
        }

        void LogException(string path, Exception ex)
        {
            using (StreamWriter writer = File.AppendText($"{path + ex.Message}.txt"))
            {
                string currentDateTime = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                writer.WriteLine($"{DateTime.Now}: {ex.Message} : {ex.StackTrace}");
                writer.Flush();
            }
        }
    }
}
