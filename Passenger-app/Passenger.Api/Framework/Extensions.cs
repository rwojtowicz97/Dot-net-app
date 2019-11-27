using Microsoft.AspNetCore.Builder;

namespace Passenger.Api.Framework
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionHandler2(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ExceptionHandlerMiddleware));
    }
}