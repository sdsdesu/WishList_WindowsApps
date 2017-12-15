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
    public sealed partial class ProfileView : Page
    {
        RuntimeInfo Runtime { get; set; }
        Wishlist Favorites { get; set; }

        public ProfileView()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User u = e.Parameter as User;
            Favorites = u.Favorites;
            username.Text = u.getFullName();
            email.Text = "Email: " + u.Email;
            FavoriteFrame.Navigate(typeof(FavoriteWishes), u);
            if (u == Runtime.LoggedInUser)
            {
                ButtonAdd.Visibility = Visibility.Visible;
            }
            else {
                ButtonAdd.Visibility = Visibility.Collapsed;
            }
        }

        public void AddFavorite_Click(object sender, RoutedEventArgs e)
        {
            FavoriteFrame.Navigate(typeof(NieweItem), Favorites);
        }
    }
}
