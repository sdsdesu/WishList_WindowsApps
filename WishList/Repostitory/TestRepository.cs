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
        List<User> users;

        public TestRepository()
        {
            User UserOne = new User("Timo", "Spanhove", "timo.spanhove@hotmail.com");
            User UserTwo = new User("Sander", "De Sutter", "Sander.desutter@hotmail.com");
            User UserThree = new User("Victor", "Van Weyenberg", "Vic.VW@hotmail.com");

            UserOne.addContact(UserThree);
            UserTwo.addContact(UserOne);
            UserTwo.addContact(UserThree);

            Event occasion1 = new Event("Graduation party", "school after party", new DateTime(2018, 2, 28));
            Event occasion2 = new Event("Birthday", "live at chucky cheese", new DateTime(2017, 11, 25));
            Event occasion3 = new Event("Christmas", "Is this still about jesus", new DateTime(2017, 12, 25));

            Wishlist wishlist1 = new Wishlist("Fuck da police", occasion1);
            Wishlist wishlist2 = new Wishlist("Gimme stuff", occasion2);
            Wishlist wishlist3 = new Wishlist("Jolly fat man", occasion3);

            wishlist1.addBuyer(UserThree);
            wishlist2.addBuyer(UserOne);
            wishlist2.addBuyer(UserThree);

            Item gift1 = new Item("Gameboy","Old school tech", Category.Tech);
            Item gift2 = new Item("Lawn mower", "Why the hell not", Category.Garden);
            Item gift3 = new Item("50 shades of gray", "Because I hate myself", Category.Literature);
            Item gift4 = new Item("The illegalest of drugs", "Wouldn't be a party otherwise", Category.Consumable);

            wishlist1.addItem(gift1);
            wishlist1.addItem(gift4);
            wishlist2.addItem(gift2);
            wishlist2.addItem(gift3);

            UserOne.addWishlist(wishlist1);
            UserTwo.addWishlist(wishlist2);
            UserTwo.addWishlist(wishlist3);

            users.Add(UserOne);
            users.Add(UserTwo);
            users.Add(UserThree);

        }

    }
}
