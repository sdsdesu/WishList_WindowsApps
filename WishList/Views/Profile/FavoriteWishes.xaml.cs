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

namespace WishList.Views.Profile
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FavoriteWishes : Page
    {
        RuntimeInfo Runtime { get; }
        Item SelectedWishlistItem { get; set; }
        public ObservableCollection<Item> FavoriteItems = new ObservableCollection<Item>();

        public FavoriteWishes()
        {

            this.InitializeComponent();
            Runtime = RuntimeInfo.Instance;
            

            foreach (Item i in Runtime.LoggedInUser.Favorites.Items)
            {
                FavoriteItems.Add(i);
            }
            FavoriteGifts.DataContext = FavoriteItems;


        }

        private void SelectionChanged_Item(object sender, SelectionChangedEventArgs e)
        {
            if (FavoriteGifts.SelectedItem != null)
            {
                SelectedWishlistItem = (Item)FavoriteGifts.SelectedItem;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User Friend = e.Parameter as User;
            if (Friend != null)
            {
                FavoriteItems = new ObservableCollection<Item>();
                foreach (Item i in Friend.Favorites.Items)
                {
                    FavoriteItems.Add(i);
                }
                FavoriteGifts.DataContext = FavoriteItems;
            }

        }
    }
}
