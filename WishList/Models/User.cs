using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    class User
    {
        //Variable declaration with getters and setters
        private int UserId { get; set; }                    //id of user
        private string Firstname { get; set; }              //name of user
        private string Lastname { get; set; }               
        private string Email { get; set; }                  //email of user, can be used to add user to contacts/friendlist
        private List<User> Contacts { get; set; }           //list of people the user can add to his wishlist (get from phone contact list or facebook account)
        private List<Wishlist> MyWishlists { get; set; }    //Wishlists of the user - functionality(wishlist stays for owner even after deadline, and all the buyers become visible to him)
        private List<Wishlist> OthersWishlists { get; set; }//Wishlists currently participating in
        private Wishlist Favorites { get; set; }            //Single wishlist containing gift that fit in any occasion, like favorite flowers, choclate, candy, wine, giftcards of specific stores, favorite authors for books...





    }
}
