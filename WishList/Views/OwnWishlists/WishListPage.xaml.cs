using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WishListPage : Page
    {
        RuntimeInfo Runtime { get; }
        Wishlist SelectedWishlist { get; set; }
        Item SelectedWishlistItem { get; set; }
        public ObservableCollection<Item> WishlistItems = new ObservableCollection<Item>();

        public WishListPage()
        {
            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
            SelectedWishlist = Runtime.AppController.SelectedWishlist;
            Title.Text = SelectedWishlist.Title;

            myWishlistItems.Height = Runtime.ScreenHeight/1.2;
            myWishlistItems.Width = Runtime.ScreenWidth;
            

            foreach (Item i in SelectedWishlist.Items)
            {
                WishlistItems.Add(i);
            }
            myWishlistItems.DataContext = WishlistItems;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(NieweItem));
        }

        private void SelectionChanged_WishlistItem(object sender, SelectionChangedEventArgs e)
        {
            if (myWishlistItems.SelectedItem != null)
            {
                SelectedWishlistItem = (Item)myWishlistItems.SelectedItem;
                ButtonRemove.Visibility = Visibility.Visible;
            }

            var listBox = sender as ListBox;
            //get unselected item
            var unselectedPerson = e.RemovedItems.FirstOrDefault() as Item;
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


    }
}
