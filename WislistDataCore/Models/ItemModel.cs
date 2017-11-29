using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class ItemModel
    {
       
        private int ItemId { get; set; }                        //id of item
        private string Name { get; set; }//name of the item
        [ForeignKey("WishlistModel")]
        private string Description { get; set; }                //item description - semi optional when you give a store link
        private string WebLink { get; set; }                    //link to the item in an online store
        private string Image { get; set; }                      // hyperlink to image 
        public int toWishListId { get; set; }
        private CategoryModel Category { get; set; }            //item category for filtering and determening order of item presentation
 

    }
}
