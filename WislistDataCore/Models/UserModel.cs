using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class UserModel { 
     //  [PrimariKey]
        private int UserId { get; set; }                    //id of user    //unique generated on creation
        private string Firstname { get; set; }              //name of user
        private string Lastname { get; set; }
    }
}
