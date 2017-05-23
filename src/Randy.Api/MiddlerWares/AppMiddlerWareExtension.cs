using Microsoft.AspNetCore.Builder;

namespace Randy.Api
{
    public static class AppMiddlerWareExtension
    {
        public static IApplicationBuilder JWTMiddlerWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlerWares.JWTMiddlerWare>();
        }
    }
}
