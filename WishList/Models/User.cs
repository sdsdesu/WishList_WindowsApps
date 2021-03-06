﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishList.Models
{
    public class User : INotifyPropertyChanged
    {
        //Variable declaration with getters and setters
        public int UserId { get; set; }                    //id of user    //unique generated on creation
        public string Firstname { get; set; }              //name of user
        public string Lastname { get; set; }
        public string Email { get; set; }                  //email of user, can be used to add user to contacts/friendlist
        public ObservableCollection<User> Contacts { get; set; }           //list of people the user can add to his wishlist (get from phone contact list or facebook account)
        public ObservableCollection<Message> Notifications { get; set; }
        public ObservableCollection<Wishlist> MyWishlists { get; set; }    //Wishlists of the user - functionality(wishlist stays for owner even after deadline, and all the buyers become visible to him)
        public ObservableCollection<Wishlist> OthersWishlists { get; set; }//Wishlists currently participating in
        public Wishlist Favorites { get; set; }            //Single wishlist containing gift that fit in any occasion, like favorite flowers, choclate, candy, wine, giftcards of specific stores, favorite authors for books...

        //STill needs image added once db in order

        //Constructors
        public User(string firstname, string lastname, string email)
        {
            //Look up how to do unique id !!! TO DO
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Contacts = new ObservableCollection<User>();
            Notifications = new ObservableCollection<Message>();
            MyWishlists = new ObservableCollection<Wishlist>();
            OthersWishlists = new ObservableCollection<Wishlist>();
            Favorites = new Wishlist("Mijn favoriete cadeau's", "General");
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        //Functions
        //Function 1)GetFullName
        public string getFullName() {
            string fullname = String.Format("{0} {1}", Firstname, Lastname);
            return fullname;
        }

        //Function 2)AddContact - add single user to contact list
        public void addContact(User contact) {
            //AppController gets given email string, looks in database for user retrieves it and calls this function
            Contacts.Add(contact);
            foreach (Wishlist w in contact.MyWishlists) {
                OthersWishlists.Add(w);
            }
        }

        public void addNotification(Message m) {
            Notifications.Add(m);
        }

        //Function 3)AddWishlist
        public void addWishlist(Wishlist wishlist) {
            MyWishlists.Add(wishlist);
        }
        public void removeWishlist(Wishlist wishlist) {
            MyWishlists.Remove(wishlist);
        }

        //Function 4)CheckIfOwner - check if user is owner of wishlist
        public bool isOwner(Wishlist w) {
            if(MyWishlists.Contains(w))
                return true;
            return false;
        }

        public ObservableCollection<Wishlist> getMyWishlists() {
            return MyWishlists;
        }

        public void FillFavorites(ObservableCollection<Item> gifts) {
            Favorites.Items = gifts;
        }

    }
}
