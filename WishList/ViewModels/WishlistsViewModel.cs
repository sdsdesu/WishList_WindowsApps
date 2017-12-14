using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Controllers;
using WishList.Models;

namespace WishList.ViewModels
{

    class WishlistsViewModel
    {
        //Variables
        RuntimeInfo Runtime;
        public Wishlist SelectedWishlist { get; set; }


        public WishlistsViewModel(){
            Runtime = RuntimeInfo.Instance;
            User user = Runtime.LoggedInUser;
         

        }

    }
}
