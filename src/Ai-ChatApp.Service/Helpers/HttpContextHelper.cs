using Microsoft.AspNetCore.Http;

namespace Ai_ChatApp.Service.Helpers;

public static class HttpContextHelper
{
    public static IHttpContextAccessor ContextAccessor { get; set; }
    public static HttpContext HttpContext => ContextAccessor?.HttpContext;
    public static IHeaderDictionary ResponseHeaders => HttpContext?.Response?.Headers;
    public static long UserId => Convert.ToInt64(HttpContext?.User?.FindFirst("Id")?.Value);
}