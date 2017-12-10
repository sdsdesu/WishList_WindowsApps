using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    public class Message
    {
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public Boolean IsInvite { get; set; }              //Is invite to join wishlist or is request by friend to join wishlist
        public Boolean IsAccepted { get; set; }            //not really needed if we delete messages that have been handled, however if we want to keep messagelog but not allow another accept we could use this
        public Wishlist RelatedWishlist { get; set; }      //wishlist to join or invite to


        //Constructors
        public Message(User loggedInUser, User selectedContact, Boolean isInvite, Wishlist relatedWishlist)
        {
            Sender = loggedInUser;
            Receiver = selectedContact;
            IsInvite = isInvite;
            RelatedWishlist = relatedWishlist;

            IsAccepted = false;
        }


    }
}
