using Microsoft.AspNetCore.Builder;

namespace Events.WebApi.Middleware
{
    public static class CusomExceptionHandlerMiddlewareExceptions
    {
        public static IApplicationBuilder UseCusomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CusomExceptionHandlerMiddleware>();
        }
    }
}
