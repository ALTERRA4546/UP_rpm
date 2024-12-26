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

namespace Ticket17
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

        private void CalculatePowerButton_Click(object sender, RoutedEventArgs e)
        {
            int intNumber = 5;
            double doubleNumber = 2.5;

            int intResult = Power(intNumber);
            double doubleResult = Power(doubleNumber);

            resultTextBlock.Text = $"Integer {intNumber} squared: {intResult}\n" +
                                    $"Double {doubleNumber} cubed: {doubleResult}";
        }

        private int Power(int number)
        {
            return number * number;
        }
        private double Power(double number)
        {
            return number * number * number;
        }
    }
}
