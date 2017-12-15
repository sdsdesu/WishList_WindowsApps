using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishList.Models;

namespace WishList.Repostitory
{
    public class TestRepository
    {
        public static List<User> Users { get; set; }

        public TestRepository()
        {

            Users = new List<User>();

            User UserOne = new User("Timo", "Spanhove", "timo.spanhove@hotmail.com");
            User UserTwo = new User("Sander", "De Sutter", "Sander.desutter@hotmail.com");
            User UserThree = new User("Victor", "Van Weyenberg", "Vic.VW@hotmail.com");

            UserOne.UserId = 1;
            UserTwo.UserId = 2;
            UserThree.UserId = 3;

            UserOne.addContact(UserThree);
            UserTwo.addContact(UserOne);
            UserTwo.addContact(UserThree);


            Wishlist wishlist1 = new Wishlist(UserOne, "Fuck da police", "Kerstmis", new DateTime(2018, 2, 28));
            Wishlist wishlist2 = new Wishlist(UserTwo, "Gimme stuff", "Birthday", new DateTime(2017, 11, 25));
            Wishlist wishlist3 = new Wishlist(UserTwo, "Jolly fat man", "sinterklaas", new DateTime(2017, 12, 25));
            Wishlist wishlist4 = new Wishlist(UserOne, "Nihilism", "barbecue", new DateTime(2019, 12, 30));

            wishlist1.addBuyer(UserThree);
            wishlist2.addBuyer(UserOne);
            wishlist2.addBuyer(UserThree);

            Item gift1 = new Item("Gameboy", Category.Tech, "Old school tech");
            Item gift2 = new Item("Lawn mower", Category.Garden, "Why the hell not");
            Item gift3 = new Item("50 shades of gray", Category.Literature, "Because I hate myself");
            Item gift4 = new Item("The illegalest of drugs", Category.Consumable, "Wouldn't be a party otherwise");

            ObservableCollection<Item> fav1 = new ObservableCollection<Item>();
            ObservableCollection<Item> fav2 = new ObservableCollection<Item>();

            fav1.Add(gift4); fav1.Add(gift3);
            fav2.Add(gift2); fav2.Add(gift1);

            wishlist1.addItem(gift1);
            wishlist1.addItem(gift4);
            wishlist3.addItem(gift2);
            wishlist3.addItem(gift3);

            UserOne.addWishlist(wishlist1);
            UserOne.addWishlist(wishlist4);
            UserTwo.addWishlist(wishlist2);
            UserTwo.addWishlist(wishlist3);

            UserOne.FillFavorites(fav1);
            UserThree.FillFavorites(fav2);

            Users.Add(UserOne);
            Users.Add(UserTwo);
            Users.Add(UserThree);

        }

        public List<User> GetUsers() {
            return Users;
        }

    }
}
