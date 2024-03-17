using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using EF.slotmachine;

namespace EF.extra._02.opl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private uint kassa = 5;
        private uint inzet = 0;
        private Machine mach = new Machine();
        public MainWindow()
        {
            InitializeComponent();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void BtnEuro_Click(object sender, RoutedEventArgs e)
        {
            inzet++;
            kassa--;

            if (kassa > 0) BtnEuro.IsEnabled = true;
            else BtnEuro.IsEnabled = false;

            TxtInzet.Text = inzet.ToString();
            TxtKassa.Text = kassa.ToString();

            BtnSpin.IsEnabled = true;
        }

        private void BtnSpin_Click(object sender, RoutedEventArgs e)
        {
            List<string> afbeeldingen = mach.Spin();
            Img1.Source = Bitmap(afbeeldingen[0]);
            Img2.Source = Bitmap(afbeeldingen[1]);
            Img3.Source = Bitmap(afbeeldingen[2]);

            kassa += inzet * mach.Gewonnen();
            inzet = 0;
            TxtInzet.Text = inzet.ToString();
            TxtKassa.Text = kassa.ToString();

            BtnSpin.IsEnabled = false;

            if (kassa == 0)
            {
                MessageBox.Show("Game over... Kassa is leeg", "Game Over");
                Close();
            }
        }

        private BitmapImage Bitmap(string afbeelding)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = new Uri("/Assets/" + afbeelding, UriKind.Relative);
            bmp.DecodePixelWidth = 200;
            bmp.EndInit();
            return bmp;
        }
    }
}