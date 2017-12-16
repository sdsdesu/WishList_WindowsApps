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
    public sealed partial class ProfileView : Page
    {
        RuntimeInfo Runtime { get; set; }
        WishlistViewModel WishlistViewModel { get; set;}

        public ProfileView()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User selectedUser = e.Parameter as User;
            WishlistViewModel = new WishlistViewModel(selectedUser.Favorites);
            WishlistViewModel.selectedUser = selectedUser;
            
            FavoriteFrame.Navigate(typeof(FavoriteWishes), WishlistViewModel);
            if (WishlistViewModel.selectedUser == Runtime.LoggedInUser)
            {
                WishlistViewModel.activeUser = Runtime.LoggedInUser;
                ButtonAdd.Visibility = Visibility.Visible;
            }
            else {
                ButtonAdd.Visibility = Visibility.Collapsed;
            }
            DataContext = WishlistViewModel;
        }

        public void AddFavorite_Click(object sender, RoutedEventArgs e)
        {
            FavoriteFrame.Navigate(typeof(NieweItem), WishlistViewModel);
        }
    }
}
