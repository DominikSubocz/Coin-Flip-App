using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace CoinFlipApp.Assets
{
    internal class FlipMaster
    {
        public int HeadScore { get; private set; }
        public int TailScore { get; private set; }

        private string result;

        public string Result
        {
            get { return result; }
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

            if (isHeads)
            {
                HeadScore++;
            }
            else
            {
                TailScore++;
            }

            // You can put a delay here if you want to see the result before updating the scores

        }
    }
}
