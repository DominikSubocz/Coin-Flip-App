using CoinFlipApp.Assets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CoinFlipApp
{
    /// <summary>
    /// This page is mainly reponsible for guessing the flip and adding it to the history which will also reflect on other pages.
    /// In this page, unlike in the main page the score isn't kept, the user can only guess the flip.
    /// Appropiate pop up will show up on guess flip
    /// </summary>
    /// 
    public sealed partial class GuessFlip : Page
    {
        // Observable collection, a list that can be updated when running the app
        public ObservableCollection<HistoryItem> coinFlipHistory;

        public double volume;

        public string coinType;

        public string result;

        public string duration;

        private FlipMaster coinFlipMaster;

        private VideoMaster video;


        public GuessFlip()
        {
            this.InitializeComponent();
            coinFlipMaster = new FlipMaster();
            video = new VideoMaster();

            coinFlipHistory = new ObservableCollection<HistoryItem>();

            // As soon as the video player loads the file it will play.
            videoPlayer.MediaOpened += (s, args) =>
            {
                videoPlayer.Play();
            };
            
            // As soon as the audio player loads the file it will play.
            soundPlayer.MediaOpened += (s, args) =>
            {
                soundPlayer.Play();
            };
        }

        // Video file name constructor
        // Based on parameters it constructs appropiate video name, then it returns the full filename
        // At last the appropiate video is being played
        private string GetVideoFileName(string coinType, int duration, string result)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = result;

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
        }

        // Opens or closes the menu pane
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

        // Volume change function
        // All this does is adjust the volume level based on the slider's value
        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            volume = slider.Value / 10;
            soundPlayer.Volume = volume;
        }


        // Guess method

        // Navigate to mainPage and transfer current data back
        private void CoinFlipClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {
                Frame.Navigate(typeof(MainPage), coinFlipHistory);

            }
        }

        // Receive data from mainPage on arrival.
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

        private async void GuessHeadsClicked(object sender, RoutedEventArgs e)
        {
            //bool guessed = false; // Default state 
            GuessTailsBtn.IsEnabled = false; // Disable button
            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray); // Shows user the button is disabled

            GuessHeadsBtn.IsEnabled = false;// Disable button
            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);// Shows user the button is disabled
            bool userGuessedHeads = true;
            int coinIndex = CoinComboBox.SelectedIndex; // Get the choice
            string coinType = "Gold"; // By default gold
                                      // Basic switch statement that switches coin types based on index value
                                      // Duration value, based on sliders value
            int duration = (int)durationSlider.Value;

            soundPlayer.Play();


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




            coinFlipMaster.HandleGuess(userGuessedHeads, coinType, duration);
            string result = coinFlipMaster.Result;
            string videoUri = video.ChooseVideo(coinType, duration, result);
            videoPlayer.Source = new Uri(videoUri);
            await Task.Delay(TimeSpan.FromSeconds(duration)); // Delay based on the delay value

            bool hasGuessed = coinFlipMaster.Guessed;
            // Stuff for databinding 
            var historyItem = new HistoryItem
            {
                CoinType = coinType,
                Duration = duration,
                Mode = "Guess The Flip",
                Result = result,
                Guessed = hasGuessed ? "Yes" : "No" // Short else if statement
            };

            // Add it to the history list.
            coinFlipHistory.Insert(0, historyItem);

            GuessHeadsBtn.IsEnabled = false;// Disable button
            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);// Shows user the button is disabled

            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);// Show user button is enabled
            GuessHeadsBtn.IsEnabled = true; // Enable button
            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White); // Show user button is enabled
            GuessTailsBtn.IsEnabled = true; // Enable button
        }

        private async void GuessTailsClicked(object sender, RoutedEventArgs e)
        {

            bool userGuessedHeads = false;
            int coinIndex = CoinComboBox.SelectedIndex; // Get the choice
            string coinType = "Gold"; // By default gold
                                      // Basic switch statement that switches coin types based on index value
                                      // Duration value, based on sliders value
            int duration = (int)durationSlider.Value;

            soundPlayer.Play();

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

            coinFlipMaster.HandleGuess(userGuessedHeads, coinType, duration);
            string result = coinFlipMaster.Result;
            string videoUri = video.ChooseVideo(coinType, duration, result);
            videoPlayer.Source = new Uri(videoUri);
            await Task.Delay(TimeSpan.FromSeconds(duration)); // Delay based on the delay value

            bool hasGuessed = coinFlipMaster.Guessed;

            // Stuff for databinding 
            var historyItem = new HistoryItem
            {
                CoinType = coinType,
                Duration = duration,
                Mode = "Guess The Flip",
                Result = result,
                Guessed = hasGuessed ? "Yes" : "No" // Short else if statement
            };

            // Add it to the history list.
            coinFlipHistory.Insert(0, historyItem);



            GuessHeadsBtn.IsEnabled = false;// Disable button
            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);// Shows user the button is disabled
            GuessTailsBtn.IsEnabled = false; // Disable button
            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray); // Shows user the button is disabled

            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);// Show user button is enabled
            GuessHeadsBtn.IsEnabled = true; // Enable button
            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White); // Show user button is enabled
            GuessTailsBtn.IsEnabled = true; // Enable button
        }
    }
}
