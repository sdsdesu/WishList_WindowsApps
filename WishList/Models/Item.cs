using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    class Item
    {

        //Variable declaration with getters and setters
        private int ItemId { get; set; }                        //id of item
        private string Name { get; set; }                       //name of the item
        private string Description { get; set; }                //item description - semi optional when you give a store link
        private string WebLink { get; set; }                    //link to the item in an online store
        private string Image { get; set; }                      // hyperlink to image 
        private Category Category { get; set; }                 //item category for filtering and determening order of item presentation
        private User Buyer { get; set; }                        //function isbought returns bool (if Buyer == null then not bought) - can multiple people buy same gift

        //Constructors
        public Item()
        {

        }


    }
}
