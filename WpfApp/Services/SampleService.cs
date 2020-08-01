using Microsoft.Extensions.Options;
using System;
using WpfApp.Options;

namespace WpfApp.Services
{
    public class SampleService : ISampleService
    {
        private readonly AppSettings appOptions;

        public SampleService(IOptions<AppSettings> options
            , IOptionsMonitor<AppSettings> optionsMonitor
            , IOptionsSnapshot<AppSettings> optionsSnapshot)
        {
            this.appOptions = options.Value;
            appOptions = optionsMonitor.CurrentValue;
            appOptions = optionsSnapshot.Value;
        }

        public string GetData()
        {
            var date = DateTime.Now.ToLongDateString();
            var data = appOptions.Name;
            return $"{date}\n{data}";
        }
    }
}
