using Braw_Bawbee_Toss___Coin_Flip_App.Assets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    public class HistoryService
    {
        private static HistoryService _instance;

        public List<HistoryItems> HistoryItems { get; private set; }

        private HistoryService()
        {
            HistoryItems = new List<HistoryItems>();
        }

        public static HistoryService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HistoryService();
                }
                return _instance;
            }
        }

        public void AddHistoryItem(string coinType, int duration, string mode, string result)
        {
            var newItem = new HistoryItems
            {
                CoinType = coinType,
                Duration = duration,
                Mode = mode,
                Result = result
            };

            HistoryItems.Add(newItem);
        }
    }

}
