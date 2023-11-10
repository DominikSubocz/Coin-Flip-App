using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models
{
    internal class HistoryItem
    {
        public string coinType {  get; set; }
        public string result { get; set; }

        public int duration { get; set; }

        public string mode { get; set; }

        public class HistoryItemManager
        {
            public static List<HistoryItem> GetHistoryItems()
            {
                var historyItems = new List<HistoryItem>();

                historyItems.Add(new HistoryItem { coinType = "Gold", duration = 1, mode = "Coin Flip", result = "Tails" });

                return historyItems;
            }
        }


    }
}
