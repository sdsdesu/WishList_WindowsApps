using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Controllers;
using WishList.Models;
using WishList.ViewModels.Commands;

namespace WishList.ViewModels
{

    class WishlistsViewModel
    {
        //Variables
        RuntimeInfo Runtime;
        public User activeUser { get; set; }
        public Wishlist SelectedWishlist { get; set; }
        public AddWishlistCommand addWishlist {get;set;}
        public RemoveWishlistCommand removeWishlist { get; set; }

        public WishlistsViewModel(User user){
            Runtime = RuntimeInfo.Instance;

            activeUser = user;

            //check if user same as logged in user
            if (user == Runtime.LoggedInUser) {
                //only logged in user can do this
                addWishlist = new AddWishlistCommand();
                removeWishlist = new RemoveWishlistCommand(this);
            }
         

        }


        public void AddWishlist(Wishlist wishlist)
        {
            activeUser.MyWishlists.Add(wishlist);
        }

        public void RemoveWishlistCommand()
        {
            activeUser.MyWishlists.Remove(SelectedWishlist);
        }

    }
}
