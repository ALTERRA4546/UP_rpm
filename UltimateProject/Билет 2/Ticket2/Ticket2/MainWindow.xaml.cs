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

namespace Ticket2
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

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(sizeTextBox.Text, out int arraySize) &&
                int.TryParse(maxTextBox.Text, out int maxValue) &&
                arraySize > 0 && maxValue > 0)
            {
                char[] array = GenerateRandomCharArray(arraySize, maxValue);
                originalArrayTextBox.Text = string.Join(" ", array);

                int comparisons = 0;
                char[] sortedArray = BubbleSort(array, out comparisons);
                sortedArrayTextBox.Text = string.Join(" ", sortedArray);
                complexityTextBlock.Text = $"Сложность: O(n²), сравнений: {comparisons}";
            }
            else
            {
                MessageBox.Show("Неверный формат ввода", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private char[] GenerateRandomCharArray(int size, int interval)
        {
            Random random = new Random();
            return Enumerable.Range(0, size)
                .Select(_ => (char)('a' + random.Next(interval)))
                .ToArray();
        }

        private char[] BubbleSort(char[] array, out int comparisons)
        {
            int n = array.Length;
            comparisons = 0;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        char temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
    }
}
