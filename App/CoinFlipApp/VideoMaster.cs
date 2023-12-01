using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinFlipApp
{
    /// <summary>
    /// The VideoMaster class manages the selection of video files based on coin type, duration, and result.
    /// </summary>
    public class VideoMaster
    {

        /// <summary>
        /// Chooses a video file based on the provided coin type, duration, and result.
        /// </summary>
        /// <param name="coinType">The type of coin for which the video is chosen.</param>
        /// <param name="duration">The duration of the video.</param>
        /// <param name="result">The result of the coin flip (Heads or Tails).</param>
        /// <returns>The URI of the selected video file.</returns>
        public string ChooseVideo(string coinType, int duration, string result)
        {
            string baseVideoName = $"{coinType}-{duration}";
            string resultPlaceholder = result;
            string fullVideoName = $"{baseVideoName}-{resultPlaceholder}.mp4";
            return $"ms-appx:///Assets/Videos/{fullVideoName}";
        }
    }
}
