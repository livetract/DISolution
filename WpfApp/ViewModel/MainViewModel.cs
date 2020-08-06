using System.Collections.Generic;
using WpfApp.Views;

namespace WpfApp.ViewModel
{
    public class MainViewModel:BaseViewModel
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


        private object page;
        public object Page 
        {
            get { return page; }
            set { page = value; RaisePropertyChanged(); } 
        }

        /// <summary>
        /// 配置功能
        /// </summary>
        public List<Module> Modules { get; set; }



        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }

        public RelayCommand<string> OpenCommand { get; set; }

        public void OpenPage(string name)
        {
            this.Name = name;
            //switch (name)
            //{
            //    case "文档":
            //        Page = new Document();
            //        break;
            //    case "音乐":
            //        Page = new Music();
            //        break;
            //    case "视频":
            //        Page = new Video();
            //        break;
            //    case "照片":
            //        Page = new Photo();
            //        break;
            //    case "收藏":
            //        Page = new Favorite();
            //        break;
            //    default:
            //        break;
            //}
        }
    }
}
