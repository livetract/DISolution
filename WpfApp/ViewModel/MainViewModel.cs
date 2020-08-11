using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public MainViewModel()
        {
            MenuItems = new List<MenuModule>{
            new MenuModule{Title = "文档", Name = "Document" },
            new MenuModule{Title = "音乐", Name = "Music" },
            new MenuModule{Title = "视频", Name = "Video" },
            new MenuModule{Title = "照片", Name = "Photo" },
            new MenuModule{Title = "收藏", Name = "Favorite" }
            };

            OpenCommand = new RelayCommand<string>(t => OpenPage(t));

            // 配置主页
            CurrentPage = (UserControl)CreateUsercontrol("Home");
        }


        private object currentPage;

        public object CurrentPage 
        {
            get { return currentPage; }
            set { currentPage = value; RaisePropertyChanged(); } 
        }

        /// <summary>
        /// 配置功能
        /// </summary>
        public List<MenuModule> MenuItems { get; set; }


        public RelayCommand<string> OpenCommand { get; set; }

        public void OpenPage(string name)
        {
            CurrentPage = (UserControl)CreateUsercontrol(name);
        }

        public object CreateUsercontrol(string className)
        {
            var nameSpacePath = $"WpfApp.Views.{className}";
            var type = Type.GetType(nameSpacePath);
            return Activator.CreateInstance(type);
        }
    }
}
