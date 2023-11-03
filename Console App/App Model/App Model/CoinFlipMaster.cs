using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Model
{
    internal class CoinFlipMaster
    {
        Random rnd = new Random();
        
        
        public bool flipCoin(int speed, int duration)
        {
            bool isHeads = false;
            bool isTails = false;
            int result = 0;
            for (int i = 0; i < duration; i++) 
            {
                result = rnd.Next(2);
                Console.WriteLine(result);
            }
        }

    }
}
