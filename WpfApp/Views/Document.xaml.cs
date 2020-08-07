using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp.Views
{
    /// <summary>
    /// Document.xaml 的交互逻辑
    /// </summary>
    public partial class Document : UserControl
    {
        public Document()
        {
            InitializeComponent();
        }

        private void GetAssembly_Click(object sender, RoutedEventArgs e)
        {
            var assembly = Assembly.GetExecutingAssembly();
            DisplayAssemblyInfo.Text = $"本程序集信息为：\n{assembly.FullName.ToString()}\n";
            var msg = new StringBuilder();
            var scaler = 1;
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var item in assemblies)
            {
                msg.Append($"{scaler++}\t{item.FullName}\n");
            }
            DisplayAssemblyInfo.Text += msg.ToString();
        }
    }
}
