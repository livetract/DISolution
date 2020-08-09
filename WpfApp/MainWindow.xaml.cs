using System.Windows;
using System.Windows.Input;
using WpfApp.ViewModel;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 绑定到上下文
            this.DataContext = new MainViewModel();
        }

        private void Border_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // 点击鼠标左键拖动界面
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
