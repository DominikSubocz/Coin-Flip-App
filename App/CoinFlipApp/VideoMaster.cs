using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlipApp
{
    internal class VideoMaster
    {
        public string ChooseVideo(string coinType, int duration, string result)
        {
            string baseVideoName = $"{coinType}-{duration}";
            string resultPlaceholder = result;
            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";
            return $"ms-appx:///Assets/Videos/{fullVideoName}";
        }
    }
}
