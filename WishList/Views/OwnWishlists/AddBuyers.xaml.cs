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
using WishList.Models;
using WishList.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WishList.Views.OwnWishlists
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddBuyers : Page
    {
        ContactViewModel ContactViewModel { get; set; }

        public AddBuyers()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            User u = e.Parameter as User;
            //Check if passed
            if (u != null)
            {
                ContactViewModel = new ContactViewModel(u);    //pass a selected wishlist to model so both contacts and wishlist can get updated
            }

        }

        private void SelectionChanged_buyer(object sender, SelectionChangedEventArgs e)
        {

            if (myContacts.SelectedItem != null)
            {
                
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
                }
            }
            //get selected item container
            var selectedItemContainer = listBox.ContainerFromItem(listBox.SelectedItem) as ListBoxItem;
            if (selectedItemContainer != null)//To prevent crash on removing the selected object
            {
                selectedItemContainer.ContentTemplate = (DataTemplate)this.Resources["SelectedItemView"];
            }


        }

    }
}
