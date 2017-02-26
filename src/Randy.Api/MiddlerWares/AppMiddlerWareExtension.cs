using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Api
{
    public static class AppMiddlerWareExtension
    {
        public static IApplicationBuilder TestMiddlerWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TestMiddlerWare>();
        }
    }
}
