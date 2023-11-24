using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using CoinFlipApp.Assets;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CoinFlipApp
{
    /// <summary>
    /// The MainPage containts various methods repsonsible for the main Coin Flip mode.
    /// 
    /// <param name="headScore"> Hold information on how many times Heads flipped.</param>
    /// <param name="tailScore">Hold information on how many times Tails flipped.</param>
    /// 
    /// </summary>
    public sealed partial class MainPage : Page
    {

        //private History historyPage;
        private int headScore = 0;    // Keeping score of how many times Heads showed up.  
        private int tailScore = 0;    // Keeping score of how many times Tails showed up.  
        public ObservableCollection <HistoryItem> coinFlipHistory;
        private FlipMaster coinFlipMaster;
        private VideoMaster video;


        public MainPage()
        {
            this.InitializeComponent();
            coinFlipMaster = new FlipMaster();
            video = new VideoMaster();


            coinFlipHistory = new ObservableCollection<HistoryItem>();

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar; // New Titlebar
            titleBar.BackgroundColor = Colors.Black;
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.Black;
            titleBar.ButtonForegroundColor = Colors.White;

            //historyPage = new History();


            // Only thing that this wee block below does, is it plays video as soon as it is loaded.

            videoPlayer.MediaOpened += (s, args) =>
            {
                videoPlayer.Play();
            };



        }





        // Event handler 1: Open/close menu pane when the burger menu icon is clicked.
        private void MenuClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == false)
            {

                MenuSplitView.IsPaneOpen = true;    // Opens SplitView menu pane

            }

            else if (MenuSplitView.IsPaneOpen == true)
            {
                MenuSplitView.IsPaneOpen = false;  // Closes SplitView menu pane
            }
        }

        // Event handler 2: Adjust volume of soundPlayer based on the volume slider's value.
        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            double volumeLevel = slider.Value / 10; // Holds volume value.
            soundPlayer.Volume = volumeLevel;   // Changing volume level.
        }

        // Function: Generate video file name based on coinType and duration.
        // Just basic concatenation of parameters which will form a full video name.
        // It just basically picks the right video.
        private string GetVideoFileName(string coinType, int duration, string result)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = result;

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
        }


        // Event handler 4: Perform coin flip when the Coin Flip button is clicked.
        private async void FlipCoin(object sender, RoutedEventArgs e)
        {


            FlipBtn.IsEnabled = false; // Disable button.
            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);   // Change colour to dark gray to show user the button is disabled.




            VideoMaster video = new VideoMaster();
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
            soundPlayer.Play();
            await coinFlipMaster.FlipCoin(coinType, duration);
            string result = coinFlipMaster.Result;
            string videoUri = video.ChooseVideo(coinType, duration, result);
            videoPlayer.Source = new Uri(videoUri);

            // Delegate coin flipping to CoinFlipGame



            var historyItem = new HistoryItem
            {
                CoinType = coinType,
                Duration = duration,
                Mode = "Coin Flip",
                Result = result,
                Guessed = "N/A"
            };
            await Task.Delay(TimeSpan.FromSeconds(duration));   // Delay based on the flip duration value.
            coinFlipHistory.Insert(0, historyItem);


            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.White); // Change colour back to normal to show user button is enabled now.
            FlipBtn.IsEnabled = true;                           // Enable button.
            // Update UI elements based on CoinFlipGame properties
            HeadsScoreTextBlock.Text = coinFlipMaster.HeadScore.ToString();
            TailsScoreTextBlock.Text = coinFlipMaster.TailScore.ToString();
        }

        private void GuessClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuessFlip), coinFlipHistory);

        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<HistoryItem>)
            {
                ObservableCollection<HistoryItem> receivedCollection = (ObservableCollection<HistoryItem>)e.Parameter;

                // Assign the received collection to your local ObservableCollection
                coinFlipHistory = receivedCollection;
            }
        }

        private void coinSelected(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected coin type
            int coinIndex = CoinComboBox.SelectedIndex;
            string coinType = "Gold"; // Default to Gold
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

            // Get the selected duration
            int duration = 1; // 1 by default
            if (durationSlider != null)
            {
                duration = (int)durationSlider.Value;
            }


            // Get the video file name based on the selected coin type and duration
            string video = GetVideoFileName(coinType, duration, "Heads"); // Run constructor (Heads won't affect score)

            // Update the videoPlayer source
            videoPlayer.Source = new Uri($"ms-appx:///Assets/Videos/{video}"); // Change video source
        }

        private void FlipBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
