using System.Net.Http;
using System.Windows;
using WpfApp.Services;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISampleService sampleService;
        private readonly IHttpClientFactory httpClientFactory;

        public MainWindow(ISampleService sampleService
            , IHttpClientFactory httpClientFactory)
        {
            InitializeComponent();
            this.sampleService = sampleService;
            this.httpClientFactory = httpClientFactory;
        }

        private void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            var client = httpClientFactory.CreateClient();
            HttpRequestMessage request;
            HttpResponseMessage response;
            try
            {
                request = new HttpRequestMessage(HttpMethod.Get, "https://www.baid45545u.com");
                response = (client.SendAsync(request)).Result;
                response.EnsureSuccessStatusCode();
                var status = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    TbxDisplayData.Text += $"\n\tHttpStatusCode:{status}\n";
                }
                else
                {
                    TbxDisplayData.Text = "zhaobudao";
                }
            }
            catch (System.Exception ex)
            {

                TbxDisplayData.Text += $"\n\t错误信息Exception:{ex}\n";
                //throw;
            }
            
            TbxDisplayData.Text += sampleService.GetData();
        }
    }
}
