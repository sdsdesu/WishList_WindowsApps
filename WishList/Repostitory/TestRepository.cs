using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;

namespace WishList.Repostitory
{
    class TestRepository
    {
        public static List<User> Users { get; set; }

        public TestRepository()
        {
            User UserOne = new User("Timo", "Spanhove", "timo.spanhove@hotmail.com");
            User UserTwo = new User("Sander", "De Sutter", "Sander.desutter@hotmail.com");
            User UserThree = new User("Victor", "Van Weyenberg", "Vic.VW@hotmail.com");

            UserOne.addContact(UserThree);
            UserTwo.addContact(UserOne);
            UserTwo.addContact(UserThree);


            Wishlist wishlist1 = new Wishlist("Fuck da police", new DateTime(2018, 2, 28));
            Wishlist wishlist2 = new Wishlist("Gimme stuff", new DateTime(2017, 11, 25));
            Wishlist wishlist3 = new Wishlist("Jolly fat man", new DateTime(2017, 12, 25));
            Wishlist wishlist4 = new Wishlist("Nihilism", new DateTime(2019, 12, 30));

            wishlist1.addBuyer(UserThree);
            wishlist2.addBuyer(UserOne);
            wishlist2.addBuyer(UserThree);

            Item gift1 = new Item("Gameboy","Old school tech", Category.Tech);
            Item gift2 = new Item("Lawn mower", "Why the hell not", Category.Garden);
            Item gift3 = new Item("50 shades of gray", "Because I hate myself", Category.Literature);
            Item gift4 = new Item("The illegalest of drugs", "Wouldn't be a party otherwise", Category.Consumable);

            wishlist1.addItem(gift1);
            wishlist1.addItem(gift4);
            wishlist3.addItem(gift2);
            wishlist3.addItem(gift3);

            UserOne.addWishlist(wishlist1);
            UserOne.addWishlist(wishlist4);
            UserTwo.addWishlist(wishlist2);
            UserTwo.addWishlist(wishlist3);

            Users.Add(UserOne);
            Users.Add(UserTwo);
            Users.Add(UserThree);

        }

        public List<User> GetUsers() {
            return Users;
        }

    }
}
