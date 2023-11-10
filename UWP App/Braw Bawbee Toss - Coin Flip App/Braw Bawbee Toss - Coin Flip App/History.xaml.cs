using Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models;
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
using static Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models.HistoryItem;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class History : Page
    {

        private List<HistoryItem> HistoryItems;

        public History()
        {
            this.InitializeComponent();
            HistoryItems = HistoryItemManager.GetHistoryItems();
        }

        private void GuessClicked(object sender, RoutedEventArgs e)
        {

        }

        private void MenuClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == false)
            {

                MenuSplitView.IsPaneOpen = true;

            }

            else if (MenuSplitView.IsPaneOpen == true)
            {
                MenuSplitView.IsPaneOpen = false;
            }
        }

    }
}
