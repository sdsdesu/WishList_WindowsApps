﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    public class Item
    {

        //Variable declaration with getters and setters
        public int ItemId { get; set; }                        //id of item
        public string Name { get; set; }                       //name of the item
        public string Description { get; set; }                //item description - semi optional when you give a store link
        public string WebLink { get; set; }                    //link to the item in an online store
        public string Image { get; set; }                      // hyperlink to image 
        public Category Category { get; set; }                 //item category for filtering and determening order of item presentation
        public User Buyer { get; set; }                        //function isbought returns bool (if Buyer == null then not bought) - can multiple people buy same gift
                                                               
        //Constructors
        public Item(string name, Category category)
        {
            Name = name;
            Category = category;
        }

        public Item(string name, Category category, string description) : this(name, category)
        {
            Description = description;
        }

        public Item(string name, Category category, string description, string weblink) : this(name, category, description)
        {
            WebLink = weblink;
        }






    }
}
