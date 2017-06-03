using Microsoft.AspNetCore.Builder;

namespace Randy.Api
{
    public static class AppMiddlerWareExtension
    {
        public static IApplicationBuilder TestMiddlerWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlerWares.TestMiddlerWare>();
        }
    }
}
