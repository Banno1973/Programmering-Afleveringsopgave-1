using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new (url, UriKind.Relative);
            BitmapImage image = new(uri);
           
            Billede.Source = image;   
        }

        private string FindBillede(int kortnummer)
        {
            KortKulør? kulør;
            string kortnavn;

            switch (kortnummer)
            {
                case (>= 1 and <= 13):
                    kulør = KortKulør.Spar;
                    break;
                case (>= 14 and <= 26):
                    kulør = KortKulør.Ruder;
                    break;
                case (>= 27 and <= 39):
                    kulør = KortKulør.Klør;
                    break;
                case (>= 40 and <= 52):
                    kulør = KortKulør.Hjerter;
                    break;
                default:
                    kulør = null;
                    break;
            }

            switch (kortnummer)
            {
                case 1 or 14 or 27 or 40:
                    kortnavn = "Es";
                    break;
                case 11 or 24 or 37 or 50:
                    kortnavn = "Knægt";
                    break;
                case 12 or 25 or 38 or 51:
                    kortnavn = "Dame";
                    break;
                case 13 or 26 or 39 or 52:
                    kortnavn = "Konge";
                    break;
                default:
                    kortnavn = (kortnummer - (int)kulør * 13).ToString();
                    break;
            }

            string resultat = $"{kortnavn}-{kulør}.jpg";

            return resultat;
        }

        public enum KortKulør   
        {
            Spar = 0,
            Ruder = 1,
            Klør = 2,
            Hjerter = 3
        };
    }
}
