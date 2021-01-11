using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppNet5
{
    public class CustomMiddleware
    {
        public RequestDelegate _next { get; set; }

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<h3>this is terminal middleware CustomMiddleware start </h3><br/>");
            await _next.Invoke(context);
            await context.Response.WriteAsync("<h3>this is terminal middleware CustomMiddleware end </h3><br/>");
        }
    }


    public class CustomMiddleware2
    {
        public RequestDelegate _next { get; set; }

        public CustomMiddleware2(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("<h3>this is terminal middleware CustomMiddleware2 start </h3><br/>");
            //await _next.Invoke(context);//注释掉该行，则形成短路
            await context.Response.WriteAsync("<h3>this is terminal middleware CustomMiddleware2 end </h3><br/>");
        }
    }

    public static class UseCustomMiddleware {
        public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CustomMiddleware2>();
            return app;
        }
    }
}
