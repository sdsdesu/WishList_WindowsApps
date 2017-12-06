using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class WishListModel
    {
        [Key]
        public int ListId                            {get;set;}
        public string Title                          { get; set; }
        [ForeignKey("UserModel")]
        public int UserId                            { get; set; }
        [JsonIgnore]
        public UserModel User                        {get;set;}
        public virtual ICollection<ItemModel> Items  {get; set; }
        //private string Description                 {get; set; }        
        public DateTime Deadline                     { get; set; }         





    }
}
