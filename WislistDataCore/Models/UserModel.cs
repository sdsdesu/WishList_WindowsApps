using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class UserModel
    {
        private int UserId { get; set; }                    //id of user    //unique generated on creation
        private string Firstname { get; set; }              //name of user
        private string Lastname { get; set; }
    }
}
