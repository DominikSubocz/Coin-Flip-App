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
using Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class History : Page
    {


        private MainPage mainPage;

        public List<HistoryItems> historyItems;

        public History()
        {
            this.InitializeComponent();
            historyItems = HistoryItems.ItemManager.AddItems();
            this.DataContext = this;

        }



        // Rest of your code...

        private void GuessClicked(object sender, RoutedEventArgs e)
        {

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Access the HistoryService and get the updated history
            var historyItems = HistoryService.Instance.HistoryItems;
            // Update your UI with the historyItems as needed
        }


    }
}
