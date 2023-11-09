using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Braw_Bawbee_Toss___Coin_Flip_App
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();

        private int headScore = 0;
        private int tailScore = 0;

        private double delayDuration = 0;



        public MainPage()
        {
            this.InitializeComponent();
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Colors.Black;
            titleBar.ForegroundColor = Colors.White;
            titleBar.ButtonBackgroundColor = Colors.Black;
            titleBar.ButtonForegroundColor = Colors.White;

            this.InitializeComponent();
            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));

        }

        public double PlaybackRate { get; set; }

        private void MenuClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == false) 
            { 

                MenuSplitView.IsPaneOpen = true;

            }

            else if (MenuSplitView.IsPaneOpen == true)
            {
                MenuSplitView.IsPaneOpen = false;
            }
        }
        private void HistoryClicked(object sender, RoutedEventArgs e)
        {
            if (MenuSplitView.IsPaneOpen == true)
            {
                Frame.Navigate(typeof(History));
            }
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void VolumeChanged(object sender, RangeBaseValueChangedEventArgs e)
        {       
        
        }

        private void DurChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            delayDuration = durationSlider.Value;
        }



        private void SpdChanged(object sender, RangeBaseValueChangedEventArgs e)
        {

            double newSpeed = speedSlider.Value;
        }

        private async void FlipCoin(object sender, RoutedEventArgs e)
        {

            bool isHeads = (new Random().Next(2) == 0);

            if (isHeads)
            {

                headScore++;
                resultTest.Text = "Heads";

            }

            else
            {
                tailScore++;
                resultTest.Text = "Tails";


            }


            FlipBtn.IsEnabled = false;
            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.DarkGray);

            await Task.Delay(TimeSpan.FromSeconds(delayDuration));

            FlipBtn.Background = new SolidColorBrush(Windows.UI.Colors.White);
            FlipBtn.IsEnabled = true;
            HeadsScoreTextBlock.Text = headScore.ToString();
            TailsScoreTextBlock.Text = tailScore.ToString();


        }



 
    }
}
