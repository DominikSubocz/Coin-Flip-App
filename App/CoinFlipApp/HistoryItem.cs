using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlipApp
{
    public class HistoryItem
    {
        public string CoinType { get; set; }
        public int Duration { get; set; }
        public string Result { get; set; }
        public string Guessed { get; set; }
        public string Mode { get; set; }
    }
}
