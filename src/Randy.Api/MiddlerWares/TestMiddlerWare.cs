using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Randy.Api.MiddlerWares
{
    public class TestMiddlerWare
    {
        private readonly RequestDelegate _next;

        public TestMiddlerWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            Console.WriteLine("randy test middler ware");
            await _next.Invoke(context);
        }
    }
}
