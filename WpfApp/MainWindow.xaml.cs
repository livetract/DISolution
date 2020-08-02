using System;
using System.Net;
using System.Net.Http;
using System.Threading;
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
            var url = "https://localhost:9011/api/todo";
            HttpRequestMessage request;
            HttpResponseMessage response;
            try
            {
                request = new HttpRequestMessage(HttpMethod.Get, url);
                response = (client.SendAsync(request)).Result;
                response.EnsureSuccessStatusCode();
                var status = response.StatusCode;
                if (response.IsSuccessStatusCode)
                {
                    TbxDisplayData.Text += $"\n\tHttpStatusCode:{status}\n";
                }
                else
                {
                    switch (response.StatusCode)
                    {
                        case HttpStatusCode.NotFound:
                            TbxDisplayData.Text = "找不到资源";
                            break;

                        case HttpStatusCode.BadRequest:
                            TbxDisplayData.Text = "错误的请求";
                            break;
                        case HttpStatusCode.InternalServerError:
                            TbxDisplayData.Text = "服务器故障";
                            break;
                        case HttpStatusCode.Unauthorized:
                            TbxDisplayData.Text = "未认证";
                            break;
                    }
                }
            }
            // 由于目标计算机积极拒绝，无法连接。
            catch (AggregateException ae)
            {
                TbxDisplayData.Text = $"错误信息是：\n\t{ae.Message}";
            }
            catch (System.Exception ex)
            {
                TbxDisplayData.Text += $"\n\t错误信息Exception:{ex}\n";
            }
            
            TbxDisplayData.Text += sampleService.GetData();
        }
    }
}
