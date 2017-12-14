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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using WishList.Models;
using WishList.Controllers;
using WishList.Views.Social;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Contacts : Page
    {

        public ObservableCollection<User> Friends = new ObservableCollection<User>();
        RuntimeInfo Runtime;
        public User SelectedContact { get; set; }

        public Contacts()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;

            MyFriends.Height = Runtime.ScreenHeight/1.2;
            MyFriends.Width = Runtime.ScreenWidth;

            foreach (User f in Runtime.LoggedInUser.Contacts)
            {
                Friends.Add(f);
            }
            Friends.OrderBy(x => x.Firstname);
            MyFriends.DataContext = Friends;
        }


        private void SelectionChanged_Contact(object sender, SelectionChangedEventArgs e)
        {
            if (MyFriends.SelectedItem != null)
            {
                SelectedContact = (User)MyFriends.SelectedItem;
                ButtonView.Visibility = Visibility.Visible;
            }

            var listBox = sender as ListBox;
            //get unselected item
            var unselectedPerson = e.RemovedItems.FirstOrDefault() as Wishlist;
            if (unselectedPerson != null)
            {
                //get unselected item container
                var unselectedItem = listBox.ContainerFromItem(unselectedPerson) as ListBoxItem;
                //set ContentTemplate
                unselectedItem.ContentTemplate = (DataTemplate)this.Resources["ItemView"];
            }
            //get selected item container
            var selectedItem = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
            selectedItem.ContentTemplate = (DataTemplate)this.Resources["SelectedItemView"];
        }

        public void AddFriendButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddContact));
        }
        public void ViewDetailButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProfileView), SelectedContact);
        }

    }
}
