using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;

namespace WishList.ViewModels
{
    class ContactViewModel
    {
        public Wishlist selectedWishlist { get; set; }


        public ContactViewModel(Wishlist w)
        {
            selectedWishlist = w;
        }
    }
}
