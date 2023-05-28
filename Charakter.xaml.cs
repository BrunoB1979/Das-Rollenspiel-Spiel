using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RPG
{
    /// <summary>
    /// Interaktionslogik für Charakter.xaml
    /// </summary>
    public partial class Charakter : Window
    {
        public int Kraft = 10;
        public int Ausdauer = 10;
        public int Geschwindigkeit = 10;
        public int Intelligenz = 10;
        public int Charisma = 10;
        public string Charaktername = " ";
        public string Charaktergender = " ";
        public string Charakterrasse = " ";
        public string Charakterklasse = " ";

        public Charakter()
        {
            InitializeComponent();

        }

        private void RBMale_Checked(object sender, RoutedEventArgs e)
        {
            BTN1.IsEnabled = true;
            Gender.Source = new BitmapImage(new Uri("/images/male.png", UriKind.Relative));
            TBoxGender.Text = "männlich";

        }

        private void RBFemale_Checked(object sender, RoutedEventArgs e)
        {
            BTN1.IsEnabled = true;
            Gender.Source = new BitmapImage(new Uri("/images/female.png", UriKind.Relative));
            TBoxGender.Text = "weiblich";
        }

        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            if (RBMale.IsChecked == true)
            {
                Kraft = Kraft + 1;
                Ausdauer = Ausdauer + 1;
            }
            else if (RBFemale.IsChecked == true)
            {
                Intelligenz = Intelligenz + 1;
                Charisma = Charisma + 1;
                Geschwindigkeit = Geschwindigkeit + 1;
            }
            TBoxKraft.Text = Kraft.ToString();
            TBoxAusdauer.Text = Ausdauer.ToString();
            TBoxGeschwindigkeit.Text = Geschwindigkeit.ToString();
            TBoxIntelligenz.Text = Intelligenz.ToString();
            TBoxCharisma.Text = Charisma.ToString();

            TabB.IsEnabled = true;
            TabB.IsSelected = true;
            TabA.IsEnabled = false;
        }

        private void Mensch_Checked(object sender, RoutedEventArgs e)
        {
            if (RBMale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/MenschMann.jpg", UriKind.Relative));
                TBoxRasse.Text= "Mensch";
            }
            else if (RBFemale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/MenschFrau.jpg", UriKind.Relative));
                TBoxRasse.Text = "Mensch";
            }
            BTN2.IsEnabled = true;
        }

        private void Zwerg_Checked(object sender, RoutedEventArgs e)
        {
            if (RBMale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/ZwergMann.jpg", UriKind.Relative));
                TBoxRasse.Text = "Zwerg";
            }
            else if (RBFemale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/ZwergFrau.jpg", UriKind.Relative));
                TBoxRasse.Text = "Zwerg";
            }
            BTN2.IsEnabled = true;
        }

        private void Elf_Checked(object sender, RoutedEventArgs e)
        {
            if (RBMale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/ElbMann.jpg", UriKind.Relative));
                TBoxRasse.Text = "Elf";
            }
            else if (RBFemale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/ElbFrau.jpg", UriKind.Relative));
                TBoxRasse.Text = "Elf";
            }
            BTN2.IsEnabled = true;
        }

        private void Ork_Checked(object sender, RoutedEventArgs e)
        {
            if (RBMale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/OrkMann.jpg", UriKind.Relative));
                TBoxRasse.Text = "Ork";

            }
            else if (RBFemale.IsChecked == true)
            {
                Gender.Source = new BitmapImage(new Uri("/images/OrkFrau.jpg", UriKind.Relative));
                TBoxRasse.Text = "Ork";
            }
            BTN2.IsEnabled = true;
        }

        private void BTN2_Click(object sender, RoutedEventArgs e)
        {
            if (Mensch.IsChecked == true)
                {
                Ausdauer = Ausdauer + 1;
                Geschwindigkeit = Geschwindigkeit + 1;
                Intelligenz = Intelligenz + 1;
                }
               
            else if (Zwerg.IsChecked == true)
            {
                Kraft = Kraft + 1;
                Ausdauer = Ausdauer + 2;
            }
            else if (Elf.IsChecked == true)
            {
                Geschwindigkeit = Geschwindigkeit +1;
                Intelligenz = Intelligenz + 1;
                Charisma = Charisma + 1;
            }
            else if (Ork.IsChecked == true)
            {
                Kraft = Kraft + 3;
                Ausdauer = Ausdauer + 2;
                Intelligenz = Intelligenz -1;
                Charisma = Charisma - 2;
            }
            TBoxKraft.Text = Kraft.ToString();
            TBoxAusdauer.Text = Ausdauer.ToString();
            TBoxGeschwindigkeit.Text = Geschwindigkeit.ToString();
            TBoxIntelligenz.Text = Intelligenz.ToString();
            TBoxCharisma.Text = Charisma.ToString();

            TabC.IsEnabled = true;
            TabC.IsSelected = true;
            TabB.IsEnabled = false;
        }

        private void Krieger_Checked(object sender, RoutedEventArgs e)
        {
            TBoxBeruf.Text = "Krieger";
            BTN4.IsEnabled = true;
        }

        private void Schurke_Checked(object sender, RoutedEventArgs e)
        {
            TBoxBeruf.Text = "Schurke";
            BTN4.IsEnabled = true;
        }

        private void Jäger_Checked(object sender, RoutedEventArgs e)
        {
            TBoxBeruf.Text = "Jäger";
            BTN4.IsEnabled = true;
        }

        private void Magier_Checked(object sender, RoutedEventArgs e)
        {
            TBoxBeruf.Text = "Magier";
            BTN4.IsEnabled = true;
        }

        private void BTN4_Click(object sender, RoutedEventArgs e)
        {
            if (Krieger.IsChecked == true)
            {
                Kraft = Kraft + 1;
                Ausdauer = Ausdauer + 1;
            }
            else if (Schurke.IsChecked == true)
            {
            Geschwindigkeit = Geschwindigkeit + 1;
            Charisma = Charisma + 1;
            }
            else if (Jäger.IsChecked == true)
            {
            Ausdauer = Ausdauer + 1;
            Geschwindigkeit = Geschwindigkeit + 1;
            }
            else if (Magier.IsChecked == true)
            {
            Kraft = Kraft - 1;
            Ausdauer = Ausdauer - 1;
            Intelligenz = Intelligenz + 2;
            Charisma = Charisma + 2;
            }

        TBoxKraft.Text = Kraft.ToString();
        TBoxAusdauer.Text = Ausdauer.ToString();
        TBoxGeschwindigkeit.Text = Geschwindigkeit.ToString();
        TBoxIntelligenz.Text = Intelligenz.ToString();
        TBoxCharisma.Text = Charisma.ToString();
        TabD.IsEnabled = true;
        TabD.IsSelected = true;
        TabC.IsEnabled = false;
        }

        private void ButtonA_Click(object sender, RoutedEventArgs e)
        {
            ButtonB.IsEnabled = true;
            ButtonA.IsEnabled = false;
        }        

        private void ButtonB_Click(object sender, RoutedEventArgs e)
        {
            ButtonC.IsEnabled = true;
            ButtonB.IsEnabled = false;
        }
        private void ButtonC_Click(object sender, RoutedEventArgs e)
        {
            ButtonD.IsEnabled = true;
            ButtonC.IsEnabled = false;
        }

        private void ButtonD_Click(object sender, RoutedEventArgs e)
        {
            ButtonE.IsEnabled = true;
            ButtonD.IsEnabled = false;
        }

        private void ButtonE_Click(object sender, RoutedEventArgs e)
        {
            ButtonF.IsEnabled = true;
            ButtonE.IsEnabled = false;
        }

        private void ButtonF_Click(object sender, RoutedEventArgs e)
        {
            BTN5.IsEnabled = true;
            ButtonF.IsEnabled = false;
        }

        private void BTN5_Click(object sender, RoutedEventArgs e)
        {
            TabE.IsEnabled = true;
            TabE.IsSelected = true;
            TabD.IsEnabled = false;
        }

    }
}
