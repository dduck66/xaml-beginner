using RestaurantManager.Models;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RestaurantManager.UniversalWindows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class OrderPage : Page
    {
        private DataManager dm = new DataManager();


        public OrderPage()
        {
            this.InitializeComponent();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        private async void AddToCurSelMenuItems_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                dm.CurrentlySelectedMenuItems.Add(this.MenuItemsList.SelectedItem.ToString());

                CurrentlySelectedMenuItemsList.ItemsSource = dm.CurrentlySelectedMenuItems;
                //CurrentlySelectedMenuItemsList.ItemsSource = dm.GetCurrentlySelectedMenuItems();
            }
            catch (Exception ex)
            {
                ContentDialog dialog = new ContentDialog();
                dialog.Content = "Something went wrong!" + ex.ToString();
                await dialog.ShowAsync();
                //throw;
            }
        }

        private async void SubmitOrder_Click(object sender, RoutedEventArgs e)
        {
            dm.OrderItems.Add(string.Join(", ", dm.GetCurrentlySelectedMenuItems()));
            dm.CurrentlySelectedMenuItems.Clear();

            //ContentDialog dialog = new ContentDialog();
            //dialog.IsPrimaryButtonEnabled = true;
            //dialog.PrimaryButtonText = "OK";
            //string s = string.Join("; ", dm.OrderItems);
            //dialog.Content = "Orders!  " + s;
            //await dialog.ShowAsync();
        }
    }
}
