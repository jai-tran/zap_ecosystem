using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ZAP.Ecosystem.Shared.Middlewares
{
    public class AcceptLanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public AcceptLanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Default locale_id for Vietnamese is 1
            int localeId = 1; 

            if (context.Request.Headers.TryGetValue("Accept-Language", out var langValues))
            {
                var lang = langValues.ToString();
                
                // If it is directly an integer (like old clients passing Accept-Language: 2)
                if (int.TryParse(lang, out var parsedLocaleId))
                {
                    localeId = parsedLocaleId;
                }
                else
                {
                    // If it is string-based ISO code
                    var firstLang = lang.Split(',')[0].Trim().ToLower();
                    if (firstLang.StartsWith("en")) localeId = 2;
                    else if (firstLang.StartsWith("vi")) localeId = 1;
                }
            }

            // Store in HttpContext items to be accessed globally
            context.Items["LocaleId"] = localeId;

            await _next(context);
        }
    }

    public static class AcceptLanguageMiddlewareExtensions
    {
        public static IApplicationBuilder UseSharedAcceptLanguage(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AcceptLanguageMiddleware>();
        }
    }
}
