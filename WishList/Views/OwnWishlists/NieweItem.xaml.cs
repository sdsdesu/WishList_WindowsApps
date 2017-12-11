using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WishList.Controllers;
using WishList.Models;
using WishList.Views.Profile;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NieweItem : Page
    {

        RuntimeInfo Runtime { get; }
        AppController Ac { get; }
        public NieweItem()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
            Ac = Runtime.AppController;

        }


        public void ButtonAdd_Click(object sender, RoutedEventArgs e)   //can only be clicked when given a 
        {
            //Create wishlist for user and add to the logged in user, appcontroller connects to database and adds it there as well
            Item i = new Item(NameWish.Text, (Category)CategoryBox.SelectedItem);
            i.WebLink = WebLink.Text;
            i.Description = DescriptionItem.Text;

            Ac.AddItem(i);
            //end testcode
            if (Ac.SelectedWishlist.Title == "Mijn favoriete cadeau's")
            {
                Frame.Navigate(typeof(FavoriteWishes));
            }
            else {
                Frame.Navigate(typeof(WishListPage));
            }
            
        }
        public void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            if (Ac.SelectedWishlist.Title == "Mijn favoriete cadeau's")
            {
                Frame.Navigate(typeof(FavoriteWishes));
            }
            else
            {
                Frame.Navigate(typeof(WishListPage));
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wishlist Favorites = e.Parameter as Wishlist;
            if (Favorites != null)
            {
                Ac.SelectedWishlist = Favorites;
            }
            WishlistName.Text = "Voor Wishlist: " + Ac.SelectedWishlist.Title;
            CategoryBox.ItemsSource = Enum.GetValues(typeof(Category));
            CategoryBox.SelectedIndex = 0; //can only be done here as contents of list are only initialized in the line above

        }

    }
}
