using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WislistDataCore.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}
