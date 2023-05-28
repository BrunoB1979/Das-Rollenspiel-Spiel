using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Threading.Tasks;

namespace RPG
{
    public partial class Hauptmenue : Window
    {
        private Image firstImage;
        private Panel MyPanel;
        private MediaPlayer player = new MediaPlayer();
        private DispatcherTimer soundTimer = new DispatcherTimer();
        private DispatcherTimer imageTimer = new DispatcherTimer();
        private DispatcherTimer growTimer = new DispatcherTimer();
        private DispatcherTimer buttonTimer = new DispatcherTimer();
        private int imageCounter = 0;

        public Hauptmenue()
        {
            InitializeComponent();

            // Initialize MyPanel and add to MainGrid
            MyPanel = new StackPanel(); // Using StackPanel, but you can choose the panel type that fits your needs.
            MyPanel.Visibility = Visibility.Hidden; // Start with the panel hidden.
            MainGrid.Children.Add(MyPanel);

           

            soundTimer.Interval = TimeSpan.FromSeconds(1);
            soundTimer.Tick += StartSound;
            soundTimer.Start();

            imageTimer.Interval = TimeSpan.FromSeconds(5);
            imageTimer.Tick += ShowImage;

            buttonTimer.Interval = TimeSpan.FromSeconds(5);
            buttonTimer.Tick += ShowButton;
        }

        private void StartSound(object sender, EventArgs e)
        {
            player.Open(new Uri(@"audio\Intro.wav", UriKind.Relative));
            player.MediaEnded += (s, _) => player.Position = TimeSpan.Zero;
            player.Play();

            soundTimer.Stop();

            imageTimer.Start();
        }

        private void ShowImage(object sender, EventArgs e)
        {
            Image image = new Image();
            string imagePath = "";

            switch (imageCounter)
            {
                case 0:
                    imagePath = @"images\Introzwerg.png";
                    imageTimer.Interval = TimeSpan.FromSeconds(5);
                    firstImage = image; // save the first image
                    break;
                case 1:
                    imagePath = @"images\Introfeind.png";
                    break;
                case 2:
                    imagePath = @"images\Introaugen.png";
                    imageTimer.Stop();
                    growTimer.Start();
                    buttonTimer.Start();  // Start the button timer after the last image
                    break;
            }

            // Create a new BitmapImage and set it as the source of the Image
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.Relative);
            bitmap.EndInit();

            image.Source = bitmap;
            image.Stretch = Stretch.UniformToFill;
            image.Opacity = 0;

            MainGrid.Children.Add(image);

            DoubleAnimation imageFadeInAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(1)),
            };

            image.BeginAnimation(Image.OpacityProperty, imageFadeInAnimation);
            imageCounter++;
        }

        private void ShowButton(object sender, EventArgs e)
        {
            // Stop the button timer
            buttonTimer.Stop();

            // Show the ButtonGrid
            ButtonGrid.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
       


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Stop the music

            Charakter charakter = new Charakter();
            charakter.Show();
            Close();
        }
    }
}

