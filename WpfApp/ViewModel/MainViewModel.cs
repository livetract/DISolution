﻿using System.Collections.Generic;

namespace WpfApp.ViewModel
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Modules = new List<Module>{
            new Module{Name = "文档" },
            new Module{Name = "音乐" },
            new Module{Name = "视频" },
            new Module{Name = "照片" },
            new Module{Name = "收藏" }
            };

            OpenCommand = new RelayCommand<string>(t => OpenPage(t));
        }


        public object Page { get; set; }

        /// <summary>
        /// 配置功能
        /// </summary>
        public List<Module> Modules { get; set; }


        public RelayCommand<string> OpenCommand { get; set; }

        public void OpenPage(string name)
        {

        }
    }
}
