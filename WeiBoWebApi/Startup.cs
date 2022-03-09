using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

namespace WeiBoWebApi
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class Startup
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public Startup(IConfiguration configuration)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            Configuration = configuration;
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public IConfiguration Configuration { get; }
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释

        /// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //////发布政策解决跨域
            ////services.AddCors(c => c.AddPolicy("any", p => p.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

            services.AddCors(op =>
            {
                op.AddPolicy("any", set =>
                {
                    set.SetIsOriginAllowed(origin => true)
                       .AllowAnyHeader()
                       .AllowAnyMethod()
                       .AllowCredentials();
                });
            });

            //注册Swagger生成器，定义一个和多个Swagger 文档
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // 添加控制器层注释，true表示显示控制器注释
                c.IncludeXmlComments(xmlPath, true);
            });

            //SignalR 中间件需要一些服务，这些服务通过调用 services.AddSignalR 进行配置。
            services.AddSignalR();

            services.AddControllers();

        }

        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("any");


            app.UseRouting();
            app.UseAuthorization();
            //app.UseEndpoints(x => { x.MapControllers(); });
            //向 ASP.NET Core 应用添加 SignalR 功能时，通过在 Startup.Configure 方法的 app.UseEndpoints 回调中调用 endpoint.MapHub 来设置 SignalR 路由。
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/chathub");
            });


            //启用中间件服务生成Swagger作为JSON终结点
            app.UseSwagger();
            //启用中间件服务对swagger-ui，指定Swagger JSON终结点
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeiBo API V1");
                c.RoutePrefix = string.Empty;
            });



        }


    }
}
