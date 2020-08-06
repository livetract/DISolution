using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WpfApp.Services;
using WpfApp.ViewModel;

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

            // 绑定到上下文
            this.DataContext = new MainViewModel();

            this.sampleService = sampleService;
            this.httpClientFactory = httpClientFactory;
        }

        private async void BtnGetData_ClickAsync(object sender, RoutedEventArgs e)
        {
            var client = httpClientFactory.CreateClient();
            var url = "https://localhost:9011/api/todo";
            HttpResponseMessage response = new HttpResponseMessage() ;
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
            }
            // 由于目标计算机积极拒绝，无法连接。
            catch(HttpRequestException hre)
            {
                TbxDisplayData.Text = $"错误信息是：\n\t{hre.Message}\n\t\t错误信息来自: HttpRequestException\n";
                switch (response.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        TbxDisplayData.Text += "错误信息是：\n\t找不到资源\n";
                        break;

                    case HttpStatusCode.BadRequest:
                        TbxDisplayData.Text += "错误信息是：\n\t错误的请求\n";
                        break;
                    case HttpStatusCode.InternalServerError:
                        TbxDisplayData.Text += "错误信息是：\n\t服务器故障\n";
                        break;
                    case HttpStatusCode.Unauthorized:
                        TbxDisplayData.Text += "错误信息是：\n\t未认证\n";
                        break;
                }
            }
            catch (Exception ex)
            {
                TbxDisplayData.Text += $"\n\t错误信息Exception:{ex}\n";
            }
            
            TbxDisplayData.Text += $"数据信息：\n\t{sampleService.GetData()}\n";
        }
    }
}
