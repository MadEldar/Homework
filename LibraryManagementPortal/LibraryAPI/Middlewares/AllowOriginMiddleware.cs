using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace LibraryAPI.Middlewares
{
    public class AllowOriginMiddleware
    {
        private readonly RequestDelegate _next;

        public AllowOriginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

            await _next(context).ConfigureAwait(false);
        }
    }

    public static class CustomMiddlewareExtension {
        public static IApplicationBuilder UseAllowOriginMiddleware(this IApplicationBuilder builder) {
            return builder.UseMiddleware<AllowOriginMiddleware>();
        }
    }
}