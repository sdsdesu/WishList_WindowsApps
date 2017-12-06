using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class ItemModel
    {
       [Key]
        public int ItemId { get; set; }                        //id of item
        public string Name { get; set; }//name of the item
        public string Description { get; set; }                //item description - semi optional when you give a store link
        public string WebLink { get; set; }                    //link to the item in an online store
        public string Image { get; set; }                      // hyperlink to image 
        [ForeignKey("WishListModel")]
        public int WishListId { get; set; }
        [JsonIgnore]
        public WishListModel WishList { get; set; }
        [ForeignKey("CategoryModel")]
        public int Categoryid { get; set; }            //item category for filtering and determening order of item presentation
        [JsonIgnore]
        public CategoryModel Category { get; set; }            //item category for filtering and determening order of item presentation
 

    }
}
