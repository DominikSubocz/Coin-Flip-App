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


        public MainPage()
        {
            this.InitializeComponent();
            coinFlipMaster = new FlipMaster();


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


            //// Stuff for multipage databinding.
            //string mode = "Coin Flip";  // Current gamemode.
            //int coinIndex = CoinComboBox.SelectedIndex; // Coin type (gold, silver, bronze)
            //string coinType = "Gold";   // By default Gold.



            //int duration = (int)durationSlider.Value;   // Hold value of how long the coin will flip for. Kind of a delay.


            //bool isHeads = (new Random().Next(2) == 0);     // Random number between 0 & 1. (False or True).
            //string result = isHeads ? "Heads" : "Tails";    // Short way of writing if else. 0 = Heads, 1 = Tails.

            //string video = GetVideoFileName(coinType, duration, result);

            //video = video.Replace("{result}", result);      // Video replacement.
            //soundPlayer.Play();                             // Play SFX.
            //videoPlayer.Source = new Uri($"ms-appx:///Assets/Videos/{video}");  // Change video source.

            //// Stuff for databinding (not working).
            //var historyItem = new HistoryItem
            //{
            //    CoinType = coinType,
            //    Duration = duration,
            //    Mode = mode,
            //    Result = result,
            //    Guessed = "N/A"
            //};

            //// Add it to the history list (not working).
            //coinFlipHistory.Insert(0, historyItem);


            //// Basic if statement, score of one will increment based on the boolean generated.
            //if (isHeads)
            //{
            //    headScore++;    // Heads score incremented.
            //    videoPlayer.Play();

            //}

            //else
            //{
            //    tailScore++;    // Heads score incremented.
            //    videoPlayer.Play();
            //}


            //FlipBtn.IsEnabled = false; // Disable button.
            //FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);   // Change colour to dark gray to show user the button is disabled.

            //await Task.Delay(TimeSpan.FromSeconds(duration));   // Delay based on the flip duration value.


            //FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.White); // Change colour back to normal to show user button is enabled now.
            //FlipBtn.IsEnabled = true;                           // Enable button.
            //HeadsScoreTextBlock.Text = headScore.ToString(); // Update textboxes, convert int to string.
            //TailsScoreTextBlock.Text = tailScore.ToString();    // Update textboxes, convert int to string.
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

            // Update UI elements based on CoinFlipGame properties
            HeadsScoreTextBlock.Text = coinFlipMaster.HeadScore.ToString();
            TailsScoreTextBlock.Text = coinFlipMaster.TailScore.ToString();

            var historyItem = new HistoryItem
            {
                CoinType = coinType,
                Duration = duration,
                Mode = "Coin Flip",
                Result = result,
                Guessed = "N/A"
            };
            await Task.Delay(duration); // Adjust the delay time as needed
            coinFlipHistory.Insert(0, historyItem);

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
    }
}
