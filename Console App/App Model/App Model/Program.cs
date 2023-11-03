namespace App_Model
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CoinFlipMaster flip = new CoinFlipMaster();
            string result = flip.flipCoin(1, 10);
            Console.WriteLine(result);
        }
    }
}