using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;
using WishList.ViewModels.Commands;

namespace WishList.ViewModels
{
    class ContactViewModel
    {
        public User activeUser { get; set; }
        public User selectedContact { get; set; }
        public Message selectedMessage { get; set; }
        public AcceptMessageCommand acceptRequest { get; set; }
        public DenyMessageCommand denyRequest { get; set; }



        public ContactViewModel(User u)
        {
            activeUser = u;
            acceptRequest = new AcceptMessageCommand(this);
            denyRequest = new DenyMessageCommand(this);
        }


        public void AcceptRequest() {

        }

        public void DenyRequest()
        {

        }

    }
}
