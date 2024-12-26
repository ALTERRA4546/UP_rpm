using System;
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
using System.Windows.Shapes;

namespace Ticket5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FontStyle_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && SampleTextBox != null)
            {
                if (radioButton.Content.ToString() == "Normal")
                {
                    SampleTextBox.FontStyle = FontStyles.Normal;
                    SampleTextBox.FontWeight = FontWeights.Normal;
                }
                else if (radioButton.Content.ToString() == "Italic")
                {
                    SampleTextBox.FontStyle = FontStyles.Italic;
                    SampleTextBox.FontWeight = FontWeights.Normal;
                }
                else if (radioButton.Content.ToString() == "Oblique")
                {
                    SampleTextBox.FontStyle = FontStyles.Oblique;
                    SampleTextBox.FontWeight = FontWeights.Normal;
                }
                else if (radioButton.Content.ToString() == "Bold")
                {
                    SampleTextBox.FontStyle = FontStyles.Normal;
                    SampleTextBox.FontWeight = FontWeights.Bold;
                }
            }
        }

        private void FontSize_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && int.TryParse(radioButton.Content.ToString(), out int fontSize) && SampleTextBox != null)
            {
                SampleTextBox.FontSize = fontSize;
            }
        }

        private void FontColor_Checked(object sender, RoutedEventArgs e)
        {
            if (sender is RadioButton radioButton && SampleTextBox != null)
            {
                if (radioButton.Content.ToString() == "Black")
                    SampleTextBox.Foreground = Brushes.Black;
                else if (radioButton.Content.ToString() == "Red")
                    SampleTextBox.Foreground = Brushes.Red;
                else if (radioButton.Content.ToString() == "Blue")
                    SampleTextBox.Foreground = Brushes.Blue;
                else if (radioButton.Content.ToString() == "Green")
                    SampleTextBox.Foreground = Brushes.Green;
            }
        }

    }
}
