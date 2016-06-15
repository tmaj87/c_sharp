using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApplication1
{
    public partial class MainWindow : Window
    {
        private static int g_DIFFICULTY = 6;
        private static String g_NUMBER = "";
        private static int g_MODE = 3;
        private int g_helpLevel = 0;
        private Toolkit toolkit = new Toolkit();

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private async void wczytaj(object sender, RoutedEventArgs e)
        {
            g_NUMBER = toolkit.getNewNumbers(g_DIFFICULTY);

            g_wczytaj.IsEnabled = false;
            g_textBox.Text = "Zaraz wobaczysz parę cyfr, przyzwyczaj się do nich.";
            await Task.Delay(3000);
            g_textBox.Text = toolkit.divideBy(g_MODE, g_NUMBER);
            await Task.Delay(3000);

            for (int i = 0; i < 30; i++)
            {
                g_textBox.Text = getNewBoard();
                await Task.Delay(100);
            }

            displayEnding();
        }

        private void displayEnding()
        {
            g_textBox.Text = "Więc które to były?";
            g_inputBox.Text = "";
            enableTalk();
        }

        private void enableTalk()
        {
            g_inputBox.Visibility = Visibility.Visible;
            g_zapisz.IsEnabled = true;
        }

        private void disableTalk()
        {
            g_wczytaj.IsEnabled = true;
            g_zapisz.IsEnabled = false;
            g_info.Visibility = Visibility.Visible;
            g_inputBox.Visibility = Visibility.Hidden;
        }

        private void zapisz(object sender, RoutedEventArgs e)
        {
            if (g_inputBox.Text.Equals(g_NUMBER))
            {
                disableTalk();
                g_helpLevel = 0;
                g_textBox.Text = "Gratulacje!";
            }
            else
            {
                if (g_helpLevel < g_NUMBER.Length)
                {
                    g_helpLevel++;
                }
                g_textBox.Text += " Nie...";
                g_inputBox.Text = g_NUMBER.Substring(0, g_helpLevel);
            }
        }

        private void info(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1. XXY 1000pkt\n2. XYX 999pkt\n3. ZXX 998pkt\n");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            g_MODE = Int32.Parse(((RadioButton)sender).Content.ToString());
        }

        private String getNewBoard()
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(); // java lol
            for (int i = 0; i < 20; i++)
            {
                switch (toolkit.rand.Next(0, 4))
                {
                    case 0:
                        str.Append(duplicateChar(" "));
                        break;
                    case 1:
                        str.Append(duplicateChar("\t"));
                        break;
                    default:
                        str.Append(toolkit.divideBy(g_MODE, toolkit.getNewNumbers(g_DIFFICULTY)));
                        break;
                }
            }

            return str.ToString();
        }

        private String duplicateChar(String character)
        {
            String str = "";
            for (int i = 0; i < toolkit.rand.Next(2, 9); i++)
            {
                str += character;
            }
            return str;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            g_DIFFICULTY = (int)((Slider)sender).Value;
        }
    }
}
