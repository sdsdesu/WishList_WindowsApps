using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class UserModel {  // [PrimaryKey]

        [Key]
        public int UserId { get; set; }                    //id of user    //unique generated on creation
        public string Firstname { get; set; }              //name of user
        public string Lastname { get; set; }
        

    }
}
