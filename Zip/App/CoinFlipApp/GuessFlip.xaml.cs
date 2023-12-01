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

        public double volume;   // (Future Features) Parameter transfer to other pages

        public string coinType;     // (Future Features) Parameter transfer to other pages

        public string result;       // (Future Features) Parameter transfer to other pages

        public string duration;     // (Future Features) Parameter transfer to other pages

        private FlipMaster coinFlipMaster;      // (Future Features) Parameter transfer to other pages

        private VideoMaster video;      // (Future Features) Parameter transfer to other pages


        /// <summary>
        /// Initializes a new instance of the GuessFlip class.
        /// Sets up necessary components and initializes the FlipMaster and VideoMaster objects.
        /// </summary>
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

        /// <summary>
        /// Constructs the appropriate video file name based on the selected coin type, duration, and result (Heads).
        /// </summary>
        /// <param name="coinType">The selected coin type.</param>
        /// <param name="duration">The selected duration.</param>
        /// <param name="result">The result of the coin flip (Heads).</param>
        /// <returns>The full filename of the video to be played.</returns>
        private string GetVideoFileName(string coinType, int duration, string result)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = result;

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
        }

        /// <summary>
        /// Opens or closes the menu pane based on its current state.
        /// </summary>
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

        /// <summary>
        /// Adjusts the volume level based on the slider's value.
        /// </summary>
        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            volume = slider.Value / 10;
            soundPlayer.Volume = volume;
        }


        /// <summary>
        /// Handles the click event when the user selects the coin flip option from the menu.
        /// Navigates to the MainPage and transfers the current data to reflect on other pages.
        /// </summary>
        private void CoinFlipClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {
                Frame.Navigate(typeof(MainPage), coinFlipHistory);

            }
        }

        /// <summary>
        /// Receives data from MainPage upon navigation.
        /// </summary>
        /// <param name="e">Event arguments containing the received data.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<HistoryItem>)
            {
                ObservableCollection<HistoryItem> receivedCollection = (ObservableCollection<HistoryItem>)e.Parameter;

                // Assign the received collection to your local ObservableCollection
                coinFlipHistory = receivedCollection;
            }
        }

        /// <summary>
        /// Retrieves the selected coin type and sets up the video player with the appropriate video file.
        /// </summary>
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

        /// <summary>
        /// Handles the click event when the user guesses Heads.
        /// Disables the appropriate buttons, plays the flip sound, and displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
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




            coinFlipMaster.GuessFlip(userGuessedHeads, coinType, duration);
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


        /// <summary>
        /// Handles the click event when the user guesses Tails.
        /// Disables the appropriate buttons, plays the flip sound, and displays the result.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">Event arguments.</param>
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

            coinFlipMaster.GuessFlip(userGuessedHeads, coinType, duration);
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
