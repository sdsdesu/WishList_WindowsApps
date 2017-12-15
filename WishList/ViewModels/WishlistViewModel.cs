using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;
using WishList.ViewModels.Commands;

namespace WishList.ViewModels
{
    class WishlistViewModel
    {
        public Wishlist selectedWishlist { get; set; }
        public Item seletedItem { get; set; }
        public RemoveWishlistItemCommand removeItemCommand { get; set; }

        public WishlistViewModel(Wishlist w) {
            selectedWishlist = w;
            removeItemCommand = new RemoveWishlistItemCommand(this);
        }

        public void AddItem(Item item) {
            selectedWishlist.Items.Add(item);
        }

        public void AddBuyers(List<User> buyers)
        {
            foreach(User b in buyers) {
                selectedWishlist.Buyers.Add(b); 
            }
        }

        public void RemoveItem()
        {
            selectedWishlist.Items.Remove(seletedItem);
        }



    }
}
