using ConsoleApp.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            try
            {
                var sp = new ServiceCollection()
                    .AddScoped<ITestService, SignInManager>()
                    .BuildServiceProvider();    // 创建服务容器

                var userSer = sp.GetRequiredService<ITestService>();

                var userNoRequire = sp.GetService<ITestService>();  // 使用这个方法，需要自己判断是否获取了空的服务。导致返回值为空。

                var u1 = userSer.Signin("jim","134");
                var u2 = userSer.Signin("jim", "123");

                var u3 = userNoRequire.Signin("jim", "123");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
