using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class WishListModel
    {
        
        public int ListId        {get;set;}
        private string Title { get; set; }
        public UserModel User   {get;set;}
        public virtual ICollection<ItemModel> Items { get; set; }





    }
}
