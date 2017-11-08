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
        private User Owner { get; set; }                    //user that made the wishlist
        private DateTime Deadline { get; set; }         //deadline of event, when it takes place, maybe allow for days before so everything is in order before the deadline
        private List<User> Buyers{ get; set; }              //Users invited to wishlists
        private List<Item> Items { get; set; }

        //buyers can see who bought wich gift, owner can only see if a gift is bought or not
        //when deadline expires buyers lose access to the wishlist, but not the owner, owner gets to see after deadline who bought what (maybe leave some time between to not spoil things)

        //when item unbought buyer can see box to mark purchase, gives confirmation and buyers get connected to item

        //Constructors
        public Wishlist(string title)
        {
            Title = title;
        }
        public Wishlist(string title, DateTime deadline) : this(title)
        {
            Deadline = deadline;
        }


        //Functions

        //Function 1)Add Event
        public void addDeadline(DateTime deadline) {
            Deadline = Deadline;
        }

        //Function 2)AddBuyer
        public void addBuyer(User buyer) {
            Buyers.Add(buyer);
        }

        //Function 2)AddItem
        public void addItem(Item item)
        {
            Items.Add(item);
        }



    }
}
