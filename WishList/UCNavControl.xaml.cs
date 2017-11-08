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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace WishList
{
    public sealed partial class UCNavControl : UserControl
    {
        public UCNavControl()
        {
            this.InitializeComponent();
        }
        /*
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
            Frame.Navigate(typeof(Lists));
        }
        public void ButtonSocial_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListAanmaken));
        }
        */
    }
}
