using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Randy.Api.MiddlerWares
{
    public class JWTMiddlerWare
    {
        private readonly RequestDelegate nextdelegate;

        public JWTMiddlerWare(RequestDelegate next)
        {
            nextdelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("randy test middler ware");
            //context.Items.
            await nextdelegate.Invoke(context);
        }
    }
}
