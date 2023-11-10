using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public sealed partial class MainPage : Page
    {

        private History historyPage;

        private int headScore = 0;
        private int tailScore = 0;



        public MainPage()
        {
            this.InitializeComponent();

            this.DataContext = this; // Set DataContext to the current instance of MainPage
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Colors.Black;
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.Black;
            titleBar.ButtonForegroundColor = Colors.White;

            historyPage = new History();


            videoPlayer.MediaOpened += (s, args) =>
            {
                videoPlayer.Play();
            };



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



        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {       
        
        }



        private string GetVideoFileName(string coinType, int duration)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = "{result}";

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
        }

        private void HistoryClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {
                Frame.Navigate(typeof(History));
            }
        }

        private async void FlipCoin(object sender, RoutedEventArgs e)
        {
            int coinIndex = CoinComboBox.SelectedIndex;
            string coinType = "Gold";
            switch (coinIndex)
            {
                case 0:
                    coinType = "Gold";
                    break;
                case 1:
                    coinType = "Silver";
                    break;
                case 2:
                    coinType = "Bronze";
                    break;

            }

            int duration = (int)durationSlider.Value;

            string video = GetVideoFileName(coinType, duration);
            
            bool isHeads = (new Random().Next(2) == 0);
            string result = isHeads ? "Heads" : "Tails";

            video = video.Replace("{result}", result);
            videoPlayer.Source = new Uri($"ms-appx:///Assets/Videos/{video}");





            if (isHeads)
            {

                headScore++;
                videoPlayer.Play();

            }

            else
            {
                tailScore++;
                videoPlayer.Play();



            }


            FlipBtn.IsEnabled = false;
            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);

            await Task.Delay(TimeSpan.FromSeconds(duration));



            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);
            FlipBtn.IsEnabled = true;
            HeadsScoreTextBlock.Text = headScore.ToString();
            TailsScoreTextBlock.Text = tailScore.ToString();


        }

        private void GuessClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuessFlip));

        }
    }
}
