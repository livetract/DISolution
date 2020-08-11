using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WpfApp.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        public MainViewModel()
        {
            Modules = new List<Module>{
            new Module{Title = "文档", Name = "Document" },
            new Module{Title = "音乐", Name = "Music" },
            new Module{Title = "视频", Name = "Video" },
            new Module{Title = "照片", Name = "Photo" },
            new Module{Title = "收藏", Name = "Favorite" }
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
        public List<Module> Modules { get; set; }


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
