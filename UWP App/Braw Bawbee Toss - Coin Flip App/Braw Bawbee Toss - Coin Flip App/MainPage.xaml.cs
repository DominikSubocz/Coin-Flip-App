using Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
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
using static Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models.HistoryItems;


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
        private int headScore = 0;    // Keeping score of how many times Heads showed up.  
        private int tailScore = 0;    // Keeping score of how many times Tails showed up.  
        private List<HistoryItems> historyItems;


        public MainPage()
        {
            this.InitializeComponent();

            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar; // New Titlebar
            titleBar.BackgroundColor = Colors.Black;    
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.Black;
            titleBar.ButtonForegroundColor = Colors.White;

            historyPage = new History();


            // Only thing that this wee block below does, is it plays video as soon as it is loaded.

            videoPlayer.MediaOpened += (s, args) =>
            {
                videoPlayer.Play();
            };



        }

 



        // Event handler 1
        // This opens up menu pane, when the burger menu icon is clicked.
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


        // Event handler 2
        // This gets run everytime the user slides the volume slider.
        // The volume of soundPlayer will depend on the volume slider's value.
        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            double volumeLevel = slider.Value / 10;
            soundPlayer.Volume = volumeLevel;
        }


        // Function with correct parameter passing
        // This function takes two parameters coinType, and duration.
        // Then it concatenates the parameters with some trings to formulate the video file name.
        // Which will help to choose the right video.
        private string GetVideoFileName(string coinType, int duration)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = "{result}";

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
        }
        // Event handler 3
        // This gets run when the user clicks the Flip History button in the pane menu.
        // It just takes them to History Page.

        private void HistoryClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {

                Frame.Navigate(typeof(History), this);

            }
        }

        // Event handler 4
        // This gets run when the user clicks the Coin Flip button.



        private async void FlipCoin(object sender, RoutedEventArgs e)
        {

            if (DynamicStackPanel != null)
            {
                // Stuff for multipage databinding.
                string mode = "Coin Flip";
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
                soundPlayer.Play();
                videoPlayer.Source = new Uri($"ms-appx:///Assets/Videos/{video}");


                StackPanel newPanel = new StackPanel();

                // Add TextBlocks to the new StackPanel
                TextBlock coinTypeTextBlock = new TextBlock();
                coinTypeTextBlock.Text = "Coin Type: " + coinType;
                newPanel.Children.Add(coinTypeTextBlock);

                TextBlock durationTextBlock = new TextBlock();
                durationTextBlock.Text = "Duration: " + duration.ToString();
                newPanel.Children.Add(durationTextBlock);

                TextBlock modeTextBlock = new TextBlock();
                modeTextBlock.Text = "Mode: " + mode;
                newPanel.Children.Add(modeTextBlock);

                TextBlock resultTextBlock = new TextBlock();
                resultTextBlock.Text = "Result: " + result;
                newPanel.Children.Add(resultTextBlock);

                // Add the new StackPanel to the existing StackPanel
                DynamicStackPanel.Children.Insert(0, newPanel);



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


        }

        private void GuessClicked(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(GuessFlip));

        }
    }
}
