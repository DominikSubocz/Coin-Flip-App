using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace CoinFlipApp.Assets
{
    internal class FlipMaster
    {
        public int HeadScore { get; private set; }
        public int TailScore { get; private set; }

        private string result;

        private bool guessed;

        public string Result
        {
            get { return result; }
        }

        public bool Guessed
        {
            get { return guessed; }
        }

        public ObservableCollection<HistoryItem> coinFlipHistory { get; private set; }

        public FlipMaster()
        {
            HeadScore = 0;
            TailScore = 0;

            coinFlipHistory = new ObservableCollection<HistoryItem>();
        }

        public async Task FlipCoin(string coinType, int duration)
        {
            bool isHeads = (new Random().Next(2) == 0);
            result = isHeads ? "Heads" : "Tails";


            if (isHeads)
            {
                HeadScore++;
            }
            else
            {
                TailScore++;
            }

            await Task.Delay(duration); // Adjust the delay time as needed

        }

        public async Task HandleGuess(bool userGuessedHeads, string coinType, int duration)
        {
            guessed = false; // Default state
            bool isHeads = (new Random().Next(2) == 0);
            result = isHeads ? "Heads" : "Tails";

            // Basic if statement
            // It checks if the user has guessed or not
            // Displays appropriate pop-up depending on the outcome


            if (isHeads)
            {
                if (userGuessedHeads)
                {
                    await Task.Delay(duration); // Adjust the delay time as needed

                    await ShowMessageDialog("Well done! Your guess of heads was spot on!");
                }
                else
                {
                    await Task.Delay(duration); // Adjust the delay time as needed

                    await ShowMessageDialog("Oops! It's heads. Better luck next time!");
                }
            }
            else
            {
                // It checks if the user has guessed or not
                // Displays appropriate pop-up depending on the outcome
                if (!userGuessedHeads)
                {
                    await Task.Delay(duration); // Adjust the delay time as needed

                    await ShowMessageDialog("You're right! It's tails. You have a good intuition!");
                    guessed = true;
                }
                else
                {
                    await Task.Delay(duration); // Adjust the delay time as needed

                    await ShowMessageDialog("Hard luck! The coin flipped to tails this round.");
                    guessed = false;
                }
            }



        }

        private async Task ShowMessageDialog(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand("Ok", null));
            dialog.DefaultCommandIndex = 0;
            dialog.CancelCommandIndex = 1;
            var cmd = await dialog.ShowAsync();
        }
    }



}
