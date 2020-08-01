using ConsoleApp.Options;
using Microsoft.Extensions.Options;

namespace ConsoleApp.Services
{
    public class SignInManager : ITestService
    {
        private readonly MySettings mySettings;

        public SignInManager(IOptions<MySettings> setOptions
            , IOptionsMonitor<MySettings> optionsMonitor    // 热更新
            , IOptionsSnapshot<MySettings> optionsSnapshot  // 快照
            )
        {
            mySettings = setOptions.Value;
            mySettings = optionsMonitor.CurrentValue;
            mySettings = optionsSnapshot.Value;
        }
        public bool Signin(string uid, string pwd)
        {
            return uid.Equals("jim") && pwd.Equals("123");
        }
    }
}
