using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace App_2021_03_23_2.Middleware
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            String name = context.Request.Query["name"];
            if (!String.IsNullOrWhiteSpace(name)) {
                context.Request.Headers.Add("time", DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss"));
            }
            await _next(context);
        }
    }

    public static class CustomMiddlewareExtension {
        public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}