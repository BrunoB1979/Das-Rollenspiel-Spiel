using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RPG
{
    public partial class IntroB : Window
    {
        private bool isHauptmenueOpened = false;
        private MediaPlayer mediaPlayer;  // MediaPlayer-Instanz zum Abspielen des Tons

        public IntroB()
        {
            InitializeComponent();
            Loaded += IntroB_Loaded;
        }

        private void IntroB_Loaded(object sender, RoutedEventArgs e)
        {
            
            DoubleAnimation fadeInAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(2)),
                BeginTime = TimeSpan.FromSeconds(10)
            };

            ShowTextWithDelay(Title, 2, fadeInAnimation);
            ShowTextWithDelay(Subtitle, 4, fadeInAnimation);
            ShowTextWithDelay(Hint, 6, fadeInAnimation);

            DispatcherTimer fadeOutTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(12) };
            fadeOutTimer.Tick += (timerSender, args) =>
            {
                fadeOutTimer.Stop();

                PlaySound();

                FadeOutText();
            };

            fadeOutTimer.Start();
        }

        private void ShowTextWithDelay(TextBlock textBlock, double startDelay, DoubleAnimation fadeInAnimation)
        {
            fadeInAnimation.BeginTime = TimeSpan.FromSeconds(startDelay);

            textBlock.BeginAnimation(TextBlock.OpacityProperty, fadeInAnimation);
        }

        private void FadeOutText()
        {
            DoubleAnimation fadeOutAnimation = new DoubleAnimation
            {
                From = 1.0,
                To = 0.0,
                Duration = new Duration(TimeSpan.FromSeconds(2))
            };

            Title.BeginAnimation(TextBlock.OpacityProperty, fadeOutAnimation);
            Subtitle.BeginAnimation(TextBlock.OpacityProperty, fadeOutAnimation);
            Hint.BeginAnimation(TextBlock.OpacityProperty, fadeOutAnimation);
        }

        private void PlaySound()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri("audio/Space.wav", UriKind.Relative));
            mediaPlayer.Play();

            mediaPlayer.MediaOpened += (s, e) =>
            {
                if (isHauptmenueOpened) return;

                isHauptmenueOpened = true;

                DispatcherTimer closeTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(4) };
                closeTimer.Tick += (timerSender, args) =>
                {
                    closeTimer.Stop();

                    Hauptmenue hauptmenue = new Hauptmenue();
                    hauptmenue.Show();
                    Close();
                };

                closeTimer.Start();
            };
        }

    }
}