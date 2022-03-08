using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeiBoWebApi
{
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public class Program
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
    {
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public static void Main(string[] args)
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
        {
            CreateHostBuilder(args).Build().Run();
        }

#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
        public static IHostBuilder CreateHostBuilder(string[] args) =>
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
