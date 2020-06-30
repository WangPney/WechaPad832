using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Wechat.Api.Aop
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class BodyDump
    {
        private readonly RequestDelegate next;
        private readonly ILogger<BodyDump> logger;

        public BodyDump(RequestDelegate next, ILogger<BodyDump> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context == null)
            {
                await this.next(context);
                return;
            }
            if (!context.Request.Path.ToString().StartsWith("/api/"))
            {
                 await this.next(context);
                return;
            }
           // this.logger.LogDebug(">>>>>>>>>>>>>>>>>>>>>>>>>");
            string req;
            string resp;
            var timer = new Stopwatch();
            timer.Start();
            context.Request.EnableBuffering();
            using (var requestReader = new StreamReader(context.Request.Body, Encoding.UTF8, true, 4096, true))
            {
                req = await requestReader.ReadToEndAsync();
            }
            context.Request.Body.Position = 0;
            var originalResponseStream = context.Response.Body;
            using (var ms = new MemoryStream())
            {
                context.Response.Body = ms;
                await this.next(context);
                ms.Position = 0;
                var respContentType = context.Response.ContentType;
                if (respContentType?.Contains("application/json")??false)
                {
                    using (var responseReader = new StreamReader(ms, Encoding.UTF8, true, 4096, true))
                    {
                        resp = await responseReader.ReadToEndAsync();
                    }
                }
                else
                {
                    resp = "not json ,no dump";
                }
                ms.Position = 0;
                await ms.CopyToAsync(originalResponseStream);
                context.Response.Body = originalResponseStream;
            }
            timer.Stop();
            var latency = timer.ElapsedMilliseconds;
            this.logger.LogDebug($"{context.Request.Method} {context.Request.Path} {context.Request.QueryString} {context.Connection.RemoteIpAddress} latency : {latency}ms\n" +
                $"request : {req} \n" +
                $"response : {resp}");
           // this.logger.LogDebug("<<<<<<<<<<<<<<<<<<<<<<<<<<<");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class BodyDumpExtensions
    {
        public static IApplicationBuilder UseBodyDump(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BodyDump>();
        }
    }
}
