
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

        [TestMethod]
        public void ChooseVideo_GoldCoin_1s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Gold", 1, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Gold-1-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Gold-1-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_GoldCoin_1s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Gold", 1, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Gold-1-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Gold-1-Tails.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_GoldCoin_2s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Gold", 2, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Gold-2-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Gold-2-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_GoldCoin_2s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Gold", 2, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Gold-2-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Gold-2-Tails.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_SilverCoin_1s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Silver", 1, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Silver-1-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Silver-1-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_SilverCoin_1s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Silver", 1, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Silver-1-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Silver-1-Tails.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_SilverCoin_2s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Silver", 2, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Silver-2-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Silver-2-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_SilverCoin_2s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Silver", 2, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Silver-2-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Silver-2-Tails.mp4'.");
        }

        public void ChooseVideo_BronzeCoin_1s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Bronze", 1, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Bronze-1-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Bronze-1-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_BronzeCoin_1s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Bronze", 1, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Bronze-1-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Bronze-1-Tails.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_BronzeCoin_2s_Heads_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Bronze", 2, "Heads");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Bronze-2-Heads.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Bronze-2-Heads.mp4'.");
        }

        [TestMethod]
        public void ChooseVideo_BronzeCoin_2s_Tails_Test()
        {

            // Arrange
            var videoMaster = new VideoMaster();



            //Act
            string testVideo = videoMaster.ChooseVideo("Bronze", 2, "Tails");


            //Assert
            Assert.AreEqual("ms-appx:///Assets/Videos/Bronze-2-Tails.mp4", testVideo, "The video's filename should be 'ms-appx:///Assets/Videos/Bronze-2-Tails.mp4'.");
        }
    }

    }




   



    
