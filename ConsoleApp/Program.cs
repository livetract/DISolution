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
                var u1 = userSer.Signin("jim","134");
                var u2 = userSer.Signin("jim", "123");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
