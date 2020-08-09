using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            // 点击鼠标左键拖动界面
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            // 根据拖动的增量改变
            Width += e.HorizontalChange;
            Height += e.VerticalChange;
        }

        private void ClickBtnConsole(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            var tag = btn.Tag;
            switch (tag)
            {
                case "ToBar":
                    this.WindowState = WindowState.Minimized;
                    break;
                case "Max":
                    this.WindowState = WindowState.Maximized;
                    ((Button)sender).Tag = "Reduction";
                    break;
                case "Reduction":
                    this.WindowState = WindowState.Normal;
                    ((Button)sender).Tag = "Max";
                    break;
                case "Close":
                    this.Close();
                    break;
            }
        }
    }
}
