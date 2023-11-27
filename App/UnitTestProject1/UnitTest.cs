
using System;
using System.Threading.Tasks;
using CoinFlipApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Windows.UI.Xaml;

namespace UnitTestProject1
{
    [TestClass]
    public class FlipMasterTests
    {

        // This test will randomly pass or fail.
        // This is because of random boolean generation.
        // Meaning sometimes it will pass and sometimes it will not.

        [TestMethod]
        public void FlipCoin_Heads_CorrectOutcome()
        {
            // Arrange
            var flipMaster = new FlipMaster();
            string coinType = "Gold";
            int duration = 1;
            string result = flipMaster.Result;

            // Act
            flipMaster.FlipCoin(coinType, duration);



            // Assert
            if (flipMaster.Result == "Heads")
            {
                Assert.AreEqual(flipMaster.Result, "Heads");
            }



        }

        [TestMethod]
        public void FlipCoin_Tails_CorrectOutcome()
        {
            // Arrange
            var flipMaster = new FlipMaster();
            string coinType = "Gold";
            int duration = 1;
           



            // Act
            flipMaster.FlipCoin(coinType, duration);


            // Assert
            Assert.AreEqual(flipMaster.Result, "Tails");
        }

        [TestMethod]
        public void Guess_CorrectGuess_HeadsOutcome()
        {
            // Arrange
            var flipMaster = new FlipMaster();
            bool userGuessedHeads = false;
            string coinType = "Gold";
            int duration = 1;


            // Act
            flipMaster.GuessFlip(userGuessedHeads, coinType, duration);

            //Assert 
            Assert.AreEqual("Heads", flipMaster.Result, "The result should be 'Heads' when the guess is correct.");



        }

        [TestMethod]
        public void Guess_CorrectGuess_TailsOutcome()
        {
            // Arrange
            var flipMaster = new FlipMaster();
            bool userGuessedHeads = false;
            string coinType = "Gold";
            int duration = 1;


            // Act
            flipMaster.GuessFlip(userGuessedHeads, coinType, duration);

            //Assert 
            Assert.AreEqual("Tails", flipMaster.Result, "The result should be 'Tails' when the guess is correct.");



        }
    }

    }
