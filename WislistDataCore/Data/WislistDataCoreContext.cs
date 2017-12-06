using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WislistDataCore.Models;

namespace WislistDataCore.Models
{
    public class WislistDataCoreContext : DbContext
    {
        public WislistDataCoreContext (DbContextOptions<WislistDataCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WislistDataCore.Models.UserModel> UserModel { get; set; }

        public DbSet<WislistDataCore.Models.CategoryModel> CategoryModel { get; set; }

        public DbSet<WislistDataCore.Models.ItemModel> ItemModel { get; set; }

        public DbSet<WislistDataCore.Models.WishListModel> WishListModel { get; set; }
    }
}
