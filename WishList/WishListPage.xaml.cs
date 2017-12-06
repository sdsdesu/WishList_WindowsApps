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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WishListPage : Page
    {
        RuntimeInfo Runtime;
        Wishlist SelectedWishlist { get; set; }
        public ObservableCollection<Item> WishlistItems = new ObservableCollection<Item>();

        public WishListPage()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
            SelectedWishlist = Runtime.AppController.SelectedWishlist;
            Title.Text = SelectedWishlist.Title;

            foreach (Item i in SelectedWishlist.Items)
            {
                WishlistItems.Add(i);
            }
            myWishlistItems.DataContext = WishlistItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }


        ////RIP
        //public void SideBarButton_Click(object sender, RoutedEventArgs e)
        //{
        //    SplitNav.IsPaneOpen = !SplitNav.IsPaneOpen;
        //}
        //public void ButtonMyWishlists_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(Login));
        //}
        //public void ButtonOtherWishlists_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(Wishlists));
        //}
        //public void ButtonSocial_Click(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(WishListPage));
        //}
    }
}
