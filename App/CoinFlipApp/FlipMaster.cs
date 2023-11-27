using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CoinFlipApp
{
    /// <summary>
    /// The FlipMaster class manages the coin flip game, keeping track of scores, results, and user guesses.
    /// </summary>
    public class FlipMaster
    {


        public int HeadScore { get; private set; }          // Gets the score for the number of times Heads has appeared.

        public int TailScore { get; private set; }          // Gets the score for the number of times Tails has appeared.

        private string result;

        private bool isHeads;

        private bool guessed;



        public string Result
        {
            get { return result; }
        }   // Gets the current result of the coin flip (Heads or Tails).

        public bool Guessed
        {
            get { return guessed; }
        }   // Gets whether the user's guess was correct.

        public bool IsHeads
        {
            get { return isHeads; }
        }   //  Gets whether the last flip resulted in Heads.

        public ObservableCollection<HistoryItem> coinFlipHistory { get; private set; }  // Gets the history of coin flips stored in an ObservableCollection.

        /// <summary>
        /// Initializes a new instance of the FlipMaster class.
        /// Sets initial scores and creates an ObservableCollection for coin flip history.
        /// </summary>
        public FlipMaster()
        {
            HeadScore = 0;
            TailScore = 0;

            coinFlipHistory = new ObservableCollection<HistoryItem>();
        }

        /// <summary>
        /// Simulates a coin flip and updates the scores, result, and history.
        /// </summary>
        /// <param name="coinType">The type of coin being flipped.</param>
        /// <param name="duration">The duration of the coin flip animation.</param>
        public async Task FlipCoin(string coinType, int duration)
        {
            isHeads = (new Random().Next(2) == 0);
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

        /// <summary>
        /// Simulates a coin flip based on user guesses and updates the scores, result, and history.
        /// Displays a message dialog based on the outcome of the guess.
        /// </summary>
        /// <param name="userGuessedHeads">The user's guess for Heads or Tails.</param>
        /// <param name="coinType">The type of coin being flipped.</param>
        /// <param name="duration">The duration of the coin flip animation.</param>
        public async Task GuessFlip(bool userGuessedHeads, string coinType, int duration)
        {
            guessed = false; // Default state
            isHeads = (new Random().Next(2) == 0);
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

                    guessed = true;

                }
                else
                {
                    await Task.Delay(duration); // Adjust the delay time as needed

                    await ShowMessageDialog("Oops! It's heads. Better luck next time!");

                    guessed = false;
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

        /// <summary>
        /// Displays a message dialog with the provided message.
        /// </summary>
        /// <param name="message">The message to be displayed in the dialog.</param>
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
