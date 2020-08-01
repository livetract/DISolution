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

        public MainWindow(ISampleService sampleService)
        {
            InitializeComponent();
            this.sampleService = sampleService;
        }

        private void BtnGetData_Click(object sender, RoutedEventArgs e)
        {
            TbxDisplayData.Text = sampleService.GetData();
        }
    }
}
