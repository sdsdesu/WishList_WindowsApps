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
using WishList.Repostitory;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{


    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Login : Page
    {
        RuntimeInfo Runtime { get; set; }

        public Login()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
        }

        public void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            testDbAsync();


            Runtime.LoggedInUserId = 1;
            Runtime.LoggedInUser = Runtime.TestRepos.GetUsers().FirstOrDefault(u => u.UserId == 1);
            Runtime.SetUserInApp();
            Frame.Navigate(typeof(MainPage)); //mainpage is own wishlists
        }

        public async void testDbAsync() {
            ToDoItem item = new ToDoItem { Text = "awsome item", Complete = false };
            await App.MobileService.GetTable<ToDoItem>().InsertAsync(item);
        }

    }
}
