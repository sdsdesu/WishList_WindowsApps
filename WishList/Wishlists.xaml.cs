using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WishList.Repostitory;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Wishlists : Page
    {

        public ObservableCollection<Wishlist> MyWishlists = new ObservableCollection<Wishlist>();
        RuntimeInfo runtimeInfo;

        public Wishlists()
        {
            this.InitializeComponent();
            runtimeInfo = RuntimeInfo.Instance;
            TestRepository t = runtimeInfo.TestRepos;
            List<User> users = t.GetUsers();
            
            foreach(Wishlist w in users[0].getMyWishlists())
            {
                MyWishlists.Add(w);
            }
            MyWishlists.OrderBy(x => x.Title);
            myWishlists.DataContext = MyWishlists;

        }



        //NAVIGATION FUNCTIONS
        //OnClick NAVIGATION
        public void AddWishlistButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListAanmaken));
        }
        public void ViewWishlistButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListPage));
        }
        public void RemoveWishlist_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Wishlists));
        }

        //NAVBAR NAVIGATION
        public void SideBarButton_Click(object sender, RoutedEventArgs e)
        {
            SplitNav.IsPaneOpen = !SplitNav.IsPaneOpen;
        }
        public void ButtonMyWishlists_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Login));
        }
        public void ButtonOtherWishlists_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Wishlists));
        }
        public void ButtonSocial_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(WishListPage));
        }
    }


}
