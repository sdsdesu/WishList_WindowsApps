using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;

namespace WishList.ViewModels
{
    class ContactViewModel
    {
        public User activeUser { get; set; }
        public User selectedContact { get; set; }



        public ContactViewModel(User u)
        {
            activeUser = u;
        }


    }
}
