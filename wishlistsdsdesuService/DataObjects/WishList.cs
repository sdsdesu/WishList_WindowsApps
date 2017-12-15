using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wishlistsdsdesuService.DataObjects
{
    public class WishList : EntityData
    {
        public string Title { get; set; }
        public string Occassion { get; set; }
    }
}