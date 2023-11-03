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
        
        
        public string flipCoin(int speed, int duration)
        {

            int result = 0;
            for (int i = 0; i < duration; i++) 
            {
                result = rnd.Next(2);
            }

            if(result == 0)
            {
                return "Heads!";
            }
            else
            {
                return "Tails!";
            }


           
        }

    }
}
