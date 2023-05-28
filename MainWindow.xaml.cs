using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace RPG
{
    public partial class MainWindow : Window
    {
        private readonly MediaPlayer _mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += TimerTick;
            timer.Start();

            DispatcherTimer imagesDisappearTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(8) }; // Images start disappearing 6 seconds after window is loaded.
            imagesDisappearTimer.Tick += ImagesDisappearTimerTick;
            imagesDisappearTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer)?.Stop();
            _mediaPlayer.Open(new Uri("audio/Loewe.wav", UriKind.Relative));
            _mediaPlayer.Play();
        }

        private void ImagesDisappearTimerTick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer)?.Stop();

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(3))
            };

            IntroImage1.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
            IntroImage2.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);
            IntroImage3.BeginAnimation(Image.OpacityProperty, fadeOutAnimation);

            DispatcherTimer newWindowTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) }; // New window opens 3 seconds after images start disappearing.
            newWindowTimer.Tick += NewWindowTimerTick;
            newWindowTimer.Start();
        }

        private void NewWindowTimerTick(object sender, EventArgs e)
        {
            (sender as DispatcherTimer)?.Stop();
            IntroB introB = new IntroB();
            introB.Show();
            this.Close();
        }
    }
}