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
            myWishlistItems.Width = Runtime.ScreenWidth;     
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NieweItem), WishlistViewModel.selectedWishlist);
        }
        

        private void ButtonAddBuyers_Click(object sender, RoutedEventArgs e)
        {
            //navigate to differen view then shown in contacts as we only need simple list not detailed listview - but this view still uses ContactViewModel
            Frame.Navigate(typeof(AddBuyers), WishlistViewModel.selectedWishlist);
        }

        //listview layout manipulation based on selected item
        private void SelectionChanged_WishlistItem(object sender, SelectionChangedEventArgs e)
        {

            if (myWishlistItems.SelectedItem != null)
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
                if(unselectedItemContainer!=null)//To prevent crash on attempt to unselect removed object
                    unselectedItemContainer.ContentTemplate = (DataTemplate)this.Resources["ItemView"];
            }
            //get selected item container
            var selectedItemContainer = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
            if (selectedItemContainer != null)//To prevent crash on removing the selected object
                selectedItemContainer.ContentTemplate = (DataTemplate)this.Resources["SelectedItemView"];
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Wishlist selectedWishlist = e.Parameter as Wishlist;
            if (selectedWishlist != null)
            {
                WishlistViewModel = new WishlistViewModel(selectedWishlist);
                DataContext = WishlistViewModel;
            }
            else {
                throw new ArgumentNullException("Always pass a wishlist to this page");
            }
        }

    }
}
