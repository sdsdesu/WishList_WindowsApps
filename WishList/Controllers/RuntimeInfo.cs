using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;
using WishList.Repostitory;

namespace WishList.Controllers
{
    public sealed class RuntimeInfo
    {
        private static readonly RuntimeInfo _instance = new RuntimeInfo();
        public int LoggedInUserId { get; set; }
        public User LoggedInUser { get; set; }
        AppController AppController { get; set; }
        public TestRepository TestRepos { get; set; }
        

        public static RuntimeInfo Instance {
            get { return _instance; }
        }

        private RuntimeInfo() {
            TestRepos = new TestRepository();
            AppController = new AppController();
        }



    }
}
