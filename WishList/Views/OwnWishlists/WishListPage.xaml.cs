﻿using System;
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
using WishList.ViewModels;
using WishList.Views.OwnWishlists;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WishListPage : Page
    {
        RuntimeInfo Runtime { get; }
        WishlistViewModel WishlistViewModel { get; set; }
        

        public WishListPage()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;

            myWishlistItems.Height = Runtime.ScreenHeight/1.2;  //temprary method of scaling by screen
            myWishlistItems.Width = Runtime.ScreenWidth-50;     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NieweItem), WishlistViewModel);
        }
        

        private void ButtonAddBuyers_Click(object sender, RoutedEventArgs e)
        {
            //navigate to differen view then shown in contacts as we only need simple list not detailed listview - but this view still uses ContactViewModel
            Frame.Navigate(typeof(AddBuyers), WishlistViewModel.selectedWishlist);
        }

        //listview layout manipulation based on selected item
        private void SelectionChanged_WishlistItem(object sender, SelectionChangedEventArgs e)
        {

            if (myWishlistItems.SelectedItem != null && WishlistViewModel.selectedWishlist.Owner == Runtime.LoggedInUser)
            {
                ButtonRemove.Visibility = Visibility.Visible;
            }

            var listBox = sender as ListBox;
            //get unselected item
            var unselectedItem = e.RemovedItems.FirstOrDefault() as Item;
            if (unselectedItem != null)
            {
                //get unselected item container
                var unselectedItemContainer = listBox.ContainerFromItem(unselectedItem) as ListBoxItem;
                //set ContentTemplate
                if (unselectedItemContainer != null)//To prevent crash on attempt to unselect removed object
                {
                    unselectedItemContainer.ContentTemplate = (DataTemplate)this.Resources["ItemView"];
                    DetailItemBuyerButton.Visibility = Visibility.Collapsed;
                }
            }
            //get selected item container
            var selectedItemContainer = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
            if (selectedItemContainer != null)//To prevent crash on removing the selected object
            {
                selectedItemContainer.ContentTemplate = (DataTemplate)this.Resources["SelectedItemView"];
            }
            if(WishlistViewModel.selectedWishlist.Owner != Runtime.LoggedInUser)
            {
                
                if (WishlistViewModel.seletedItem.Buyer != null || WishlistViewModel.CheckUserAlreadyBought())//as long as item has been bought no need to show buybutton  or if active user has bought an item in the wishlist already
                {
                    DetailItemBuyerButton.Visibility = Visibility.Collapsed;
                    //DetailItemBuyerButton.Content = WishlistViewModel.seletedItem.Buyer.Firstname;  //possible expansion show profile of whoever bought it
                }
                else
                {
                    DetailItemBuyerButton.Visibility = Visibility.Visible;
                    DetailItemBuyerButton.Content = "Buy item";
                }
            }

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wishlist selectedWishlist = e.Parameter as Wishlist;
            if (selectedWishlist != null)
            {
                WishlistViewModel = new WishlistViewModel(selectedWishlist);
                DataContext = WishlistViewModel;
                if (selectedWishlist.Owner != Runtime.LoggedInUser) {
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    ButtonAddBuyer.Visibility = Visibility.Collapsed;
                    ButtonRemove.Visibility = Visibility.Collapsed;


                }
            }
            else {
                throw new ArgumentNullException("Always pass a wishlist to this page");
            }
        }

    }
}
