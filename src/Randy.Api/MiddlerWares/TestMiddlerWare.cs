using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Randy.Api.MiddlerWares
{
    public class TestMiddlerWare
    {
        private readonly RequestDelegate nextdelegate;

        public TestMiddlerWare(RequestDelegate next)
        {
            nextdelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("Test middler ware");
            //context.Items.
            await nextdelegate.Invoke(context);
        }
    }
}
