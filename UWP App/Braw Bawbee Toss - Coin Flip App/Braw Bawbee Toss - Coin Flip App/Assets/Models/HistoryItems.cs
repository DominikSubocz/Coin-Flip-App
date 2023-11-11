using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models;


namespace Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models
{
    public class HistoryItems
    {
        public string CoinType { get; set; }
        public int Duration { get; set; }

        public string Result { get; set; }

        public string Mode { get; set; }

        public class ItemManager
        {
            public static List<HistoryItems> GetHistoryItems()
            {
                var items = new List<HistoryItems>();

                items.Add(new HistoryItems { CoinType = "Gold", Duration = 1, Mode = "Coin Flip", Result = "Heads" });
                items.Add(new HistoryItems { CoinType = "Silver", Duration = 2, Mode = "Guess Mode", Result = "Correct" });
                items.Add(new HistoryItems { CoinType = "Bronze", Duration = 3, Mode = "Coin Flip", Result = "Tails" });

                return items;
            }
        }



    }

    
}
