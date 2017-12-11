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
using Windows.UI.StartScreen;
using WishList.Controllers;
using WishList.Views.Profile;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        RuntimeInfo Runtime { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
            Runtime.SetBounds(Window.Current.Bounds.Height, Window.Current.Bounds.Width);
            MainFrame.Navigate(typeof(Wishlists));
        }

        //THERE CAN ONLY BE ONE!
        public void SideBarButton_Click(object sender, RoutedEventArgs e) {
            SplitNav.IsPaneOpen = !SplitNav.IsPaneOpen;
        }
        public void ButtonMyProfile_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(ProfileView));
        }
        public void ButtonMyWishlists_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Wishlists));
        }
        public void ButtonOtherWishlists_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(WishlistsOthers));
        }
        public void ButtonSocial_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(SocialView));
        }

        

    }
}
