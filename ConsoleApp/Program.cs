using ConsoleApp.Options;
using ConsoleApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // 配置器
                IConfiguration config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json", false, true)
                        .Build();

                var sp = new ServiceCollection()
                    .AddScoped<ITestService, SignInManager>()
                    .AddSingleton<IConfiguration>(sp => config)
                    .Configure<MySettings>(config.GetSection("MySettings"))
                    .BuildServiceProvider();    // 创建服务容器


                config = sp.GetRequiredService<IConfiguration>();

                #region 关于服务注册的使用
                var userSer = sp.GetRequiredService<ITestService>();
                var section = config.GetSection("ApplicationName");
                var applicationName = section.Value;
                Console.WriteLine($"App名称为：{applicationName}");


                //var userNoRequire = sp.GetService<ITestService>();  // 使用这个方法，需要自己判断是否获取了空的服务。导致返回值为空。
                //if (userNoRequire != null)
                //{
                //    var u3 = userNoRequire.Signin("jim", "123");
                //}
                //else
                //{
                //    throw new NullReferenceException(nameof(userNoRequire));
                //}
                var u1 = userSer.Signin("jim", "134");
                var u2 = userSer.Signin("jim", "123");

                #endregion
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
