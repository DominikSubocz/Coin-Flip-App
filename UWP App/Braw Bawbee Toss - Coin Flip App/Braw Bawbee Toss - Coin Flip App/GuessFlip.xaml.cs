using System;
using System.Collections.Generic;
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

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=234238

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class GuessFlip : Page
    {

        private int headScore = 0;
        private int tailScore = 0;
        public GuessFlip()
        {
            this.InitializeComponent();

            videoPlayer.MediaOpened += (s, args) =>
            {
                videoPlayer.Play();
            };
        }

        private string GetVideoFileName(string coinType, int duration)
        {
            string baseVideoName = $"{coinType}-{duration}";

            string resultPlaceholder = "{result}";

            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";

            return fullVideoName;
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
        private void HistoryClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {
                Frame.Navigate(typeof(History));
            }
        }

        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

        }


        private async void FlipGuess(object sender, RoutedEventArgs e)
        {

            GuessTailsBtn.IsEnabled = false;
            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);
            GuessHeadsBtn.IsEnabled = false;
            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);



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

            await Task.Delay(TimeSpan.FromSeconds(duration));

            bool userGuessedHeads = ((sender as Button) == GuessHeadsBtn);

            if (isHeads)
            {
                if (userGuessedHeads)
                {
                    MessageDialog dialog = new MessageDialog("Well done! Your guess of heads was spot on!");
                    dialog.Commands.Add(new UICommand("Ok", null));
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var cmd = await dialog.ShowAsync();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Oops! It's heads. Better luck next time!");
                    dialog.Commands.Add(new UICommand("Ok", null));
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var cmd = await dialog.ShowAsync();
                }
            }
            else
            {
                if (!userGuessedHeads)
                {
                    MessageDialog dialog = new MessageDialog("You're right! It's tails. You have a good intuition!");
                    dialog.Commands.Add(new UICommand("Ok", null));
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var cmd = await dialog.ShowAsync();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Hard luck! The coin flipped to tails this round.");
                    dialog.Commands.Add(new UICommand("Ok", null));
                    dialog.DefaultCommandIndex = 0;
                    dialog.CancelCommandIndex = 1;
                    var cmd = await dialog.ShowAsync();
                }
            }







            GuessTailsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);
            GuessTailsBtn.IsEnabled = true;

            GuessHeadsBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);
            GuessHeadsBtn.IsEnabled = true;



        
        }
    }
}
