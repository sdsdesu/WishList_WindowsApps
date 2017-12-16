﻿using System;
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
using WishList.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WishlistsOthers : Page
    {
        RuntimeInfo Runtime;
        WishlistsViewModel WishlistsViewModel { get; set; }

        public WishlistsOthers()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;

            myWishlists.Height = Runtime.ScreenHeight - 150;
            myWishlists.Width = Runtime.ScreenWidth;
        }



        private void SelectionChanged_Wishlist(object sender, SelectionChangedEventArgs e)
        {
            if (myWishlists.SelectedItem != null)
            {
                WishlistsViewModel.SelectedWishlist = (Wishlist)myWishlists.SelectedItem;
                ButtonToWishlist.Visibility = Visibility.Visible;
            }

            var listBox = sender as ListBox;
            //get unselected item
            var unselectedWishlist = e.RemovedItems.FirstOrDefault() as Wishlist;
            if (unselectedWishlist != null)
            {
                //get unselected item container
                var unselectedItem = listBox.ContainerFromItem(unselectedWishlist) as ListBoxItem;
                //set ContentTemplate
                if (unselectedItem != null)
                    unselectedItem.ContentTemplate = (DataTemplate)this.Resources["ItemView"];
            }
            //get selected item container
            var selectedItem = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
            if (selectedItem != null)
                selectedItem.ContentTemplate = (DataTemplate)this.Resources["SelectedItemView"];

            //TODO add code to show wishlistbutton as content = view if user is buyer in wishlist or if wishlist is open  - content= request to join if wishlist not open and buyer not part of wishlist
            if (WishlistsViewModel.SelectedWishlist.IsOpen || WishlistsViewModel.SelectedWishlist.Buyers.Contains(Runtime.LoggedInUser))
            {
                ButtonToWishlist.Content = "View Wishlist";
                ButtonToWishlist.IsEnabled = true; //re enable button
            }
            else
            {
                if (WishlistsViewModel.CheckIfAlreadyRequested()) {
                    ButtonToWishlist.Content = "Request to join in progress";
                    ButtonToWishlist.IsEnabled = false; //Disable button
                }
                else {
                    ButtonToWishlist.Content = "Request to join Wishlist";
                    ButtonToWishlist.IsEnabled = true; //re enable button
                }
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User ActiveUser = e.Parameter as User;
            if (ActiveUser != null)//check if logged in
            {
                WishlistsViewModel = new WishlistsViewModel(ActiveUser);
                DataContext = WishlistsViewModel;
            }
        }

        public void ViewWishlistButton_Click(object sender, RoutedEventArgs e)
        {
            //Show wishlist to user if user is member of wishlist or if the wishlist is open
            if (WishlistsViewModel.SelectedWishlist.IsOpen || WishlistsViewModel.SelectedWishlist.Buyers.Contains(Runtime.LoggedInUser))
            {
                WishlistsViewModel.JoinWishlist();  //If you are not yet allready in list of buyers you get added automaticly, this is only for open wishllists
                Frame.Navigate(typeof(WishListPage), WishlistsViewModel.SelectedWishlist); 
            }
            else {
                WishlistsViewModel.RequestToJoin();
                ButtonToWishlist.Content = "Request has been sent."; //need a way to keep button nonclickable until request recieved and accepted
                ButtonToWishlist.IsEnabled = false; //Disable button
            }
        }

    }
}
