using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Wechat.Api;
using Wechat.Api.Aop;
using Wechat.Api.Extensions;
using Wechat.Protocol;
using Wechat.Util.Cache;
using WeChat.Api.Errors;

namespace Wechat.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => {
                options.Filters.Add(new ExceptionHandler());
            })
                .AddNewtonsoftJson(options =>
                {
                    // 忽略循环引用
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    //使用驼峰
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    //忽略空值
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            // allow cors 
            services.AddCors()
            //use Swagger to generate doc
            .AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "WeChatHelper API",
                    Version = "v1.0.0",
                    Description = "WeChatHelper API",
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "Wechat.Api.xml");
                c.IncludeXmlComments(xmlPath);
                //c.EnableAnnotations();
                c.CustomSchemaIds(
                    (type) =>  type.FullName
                    );
            });
            services.AddSingleton<RedisCache>(new RedisCache(Configuration.GetConnectionString("redis")));
            services.AddScoped<WechatHelper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseStatusCodePages(async ctx=> {
            //    var err = Error<bool>.New().WithCode(ctx.HttpContext.Response.StatusCode).WithMessage("");
            //    ctx.HttpContext.Response.ContentType = "application/json";
            //    await ctx.HttpContext.Response.BodyWriter.WriteAsync(
            //err.ToJsonString())
            //});
            app.UseBodyDump();
            app.UseStatusCodePages();
            app.UseCors(builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //if (env.IsDevelopment())
            //{
                app.UseSwagger(c => {
                    c.PreSerializeFilters.Add((swagger, httpReq) =>
                    {
                        swagger.Servers = new List<OpenApiServer> {
                        new OpenApiServer { Url = $"{httpReq.Scheme}://{httpReq.Host.Value}" },
                    };
                    });
                })
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint($"/swagger/v1/swagger.json", "WeChatHelper API");
                    c.ShowExtensions();
                    c.EnableValidator();
                    c.DisplayRequestDuration();
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                });
            //}
        }
    }
}
