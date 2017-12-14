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
using WishList.Views.Profile;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NieweItem : Page
    {

        WishlistViewModel WishlistViewModel { get; set; }

        public NieweItem()
        {
            this.InitializeComponent();
        }


        public void ButtonAdd_Click(object sender, RoutedEventArgs e)   //can only be clicked when given a 
        {
            //Create wishlist for user and add to the logged in user, appcontroller connects to database and adds it there as well
            Item i = new Item(NameWish.Text, (Category)CategoryBox.SelectedItem);
            i.WebLink = WebLink.Text;
            i.Description = DescriptionItem.Text;

            WishlistViewModel.AddItem(i);
            //end testcode
            if (WishlistViewModel.selectedWishlist.Title == "Mijn favoriete cadeau's")
            {
                Frame.Navigate(typeof(FavoriteWishes));
            }
            else {
                Frame.Navigate(typeof(WishListPage), WishlistViewModel.selectedWishlist);
            }
            
        }
        public void ButtonReturn_Click(object sender, RoutedEventArgs e)
        {
            if (WishlistViewModel.selectedWishlist.Title == "Mijn favoriete cadeau's")
            {
                Frame.Navigate(typeof(FavoriteWishes));
            }
            else
            {
                Frame.Navigate(typeof(WishListPage), WishlistViewModel.selectedWishlist);
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            Wishlist w = e.Parameter as Wishlist;
            //Check if passed
            if (w != null)
            {
                WishlistViewModel = new WishlistViewModel(w);    //replace Ac.selectedwishlist with wishlistviewmodel
            } 
            WishlistName.Text = "Voor Wishlist: " + WishlistViewModel.selectedWishlist.Title;
            CategoryBox.ItemsSource = Enum.GetValues(typeof(Category));
            CategoryBox.SelectedIndex = 0; //can only be done here as contents of list are only initialized in the line above

        }

    }
}
