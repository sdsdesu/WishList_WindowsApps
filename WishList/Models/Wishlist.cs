using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    class Wishlist
    {
        //Variable declaration with getters and setters
        private int WishlistId { get; set; }                //id of whislist
        private string Title { get; set; }                   //name of wishlist
        private Event Event { get; set; }                   //reason for wishlist - could be enum but there might be special occasions outside holidays and birthdays, like babyshowers, new home party... (also needs to contain deadline)
        private User Owner { get; set; }                    //user that made the wishlist
        private List<User> Buyers{ get; set; }              //Users invited to wishlists

        //buyers can see who bought wich gift, owner can only see if a gift is bought or not
        //when deadline expires buyers lose access to the wishlist, but not the owner, owner gets to see after deadline who bought what (maybe leave some time between to not spoil things)

        //when item unbought buyer can see box to mark purchase, gives confirmation and buyers get connected to item

    }
}
