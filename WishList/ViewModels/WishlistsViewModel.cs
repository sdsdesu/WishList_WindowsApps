using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WishList.Controllers;
using WishList.Models;
using WishList.ViewModels.Commands;

namespace WishList.ViewModels
{

    class WishlistsViewModel : INotifyPropertyChanged
    {
        //Variables
        RuntimeInfo Runtime;

        public User activeUser { get; set; }
        public Wishlist SelectedWishlist { get; set; }
        public AddWishlistCommand addWishlist {get;set;}
        public RemoveWishlistCommand removeWishlist { get; set; }
        private String _sortingMethod;
        public String SortingMethod { get { return this._sortingMethod; } set { if (_sortingMethod != value) { this._sortingMethod = value; NotifyPropertyChanged(SortingMethod); } } }
        public ObservableCollection<string> SortingMethods { get; set; } 

        //Update view by sorting
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (null != PropertyChanged)
            {
                Sort();
                PropertyChanged(this, new PropertyChangedEventArgs("activeUser"));
            }
        }



        public WishlistsViewModel(User user){
            Runtime = RuntimeInfo.Instance;

            activeUser = user;
            //SortingMethod = "Title";
            SortingMethods = new ObservableCollection<string>() { "Title", "Deadline", "Participating" };
          

            /*
            foreach (User friend in activeUser.Contacts) {
                foreach (Wishlist wishlist in friend.MyWishlists) {
                    WishlistsFromFriends.Add(wishlist);
                }
            }
            */

            //check if user same as logged in user
            if (user == Runtime.LoggedInUser) {
                //only logged in user can do this
                addWishlist = new AddWishlistCommand();
                removeWishlist = new RemoveWishlistCommand(this);
            }
        }


        public void AddWishlist(Wishlist wishlist)
        {
            activeUser.MyWishlists.Add(wishlist);
            Sort();
        }

        public void RemoveWishlistCommand()
        {
            activeUser.MyWishlists.Remove(SelectedWishlist);
        }

        public void Sort() {
            if (SortingMethod == "Title")
            {
                sortWishlistsByName();
            }
            else if (SortingMethod == "Deadline")
            {
                sortWishlistsByDeadline();
            }
            else if (SortingMethod == "Participating")
            {
                sortWishlistsByOpen();
            }
        }

        public void sortWishlistsByName() {
            activeUser.MyWishlists = new ObservableCollection<Wishlist>(activeUser.MyWishlists.OrderBy(t => t.Title));
            activeUser.OthersWishlists = new ObservableCollection<Wishlist>(activeUser.OthersWishlists.OrderBy(t => t.Title));
        }

        public void sortWishlistsByDeadline() {
            activeUser.MyWishlists = new ObservableCollection<Wishlist>(activeUser.MyWishlists.OrderBy(t => t.Deadline));
            activeUser.OthersWishlists = new ObservableCollection<Wishlist>(activeUser.OthersWishlists.OrderBy(t => t.Deadline));
        }
        public void sortWishlistsByOpen()
        {
            //only called when viewing wishlists of friends
            activeUser.MyWishlists = new ObservableCollection<Wishlist>(activeUser.MyWishlists.OrderBy(t => t.IsOpen)); // put it in so user can see which of his own wishlists he has set open
            activeUser.OthersWishlists = new ObservableCollection<Wishlist>(activeUser.OthersWishlists.OrderBy(t => t.IsOpen));      
        }

    }
}
