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

namespace Ticket18
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _randomNumber;
        private int _attempts = 0;
        private int _maxAttempts = 7;
        private List<string> _attemptsHistory = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            StartNewGame();
        }

        private void StartNewGame()
        {
            Random random = new Random();
            _randomNumber = random.Next(1, 101);
            _attempts = 0;
            _attemptsHistory.Clear();
            attemptsListBox.ItemsSource = null;
            hintTextBlock.Text = "";
            guessTextBox.IsEnabled = true;
            attemptCountTextBlock.Text = $"Попытки: {_attempts}/{_maxAttempts}";
        }

        private void GuessButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(guessTextBox.Text, out int guess))
            {
                hintTextBlock.Text = "Пожалуйста, введите корректное число.";
                return;
            }

            _attempts++;
            _attemptsHistory.Add($"Попытка {_attempts}: Ваше предположение {guess}");
            attemptsListBox.ItemsSource = null;
            attemptsListBox.ItemsSource = _attemptsHistory;
            attemptCountTextBlock.Text = $"Попытки: {_attempts}/{_maxAttempts}";


            if (guess == _randomNumber)
            {
                hintTextBlock.Text = $"Поздравляю! Вы угадали число за {_attempts} попыток.";
                guessTextBox.IsEnabled = false;
                return;
            }

            if (_attempts >= _maxAttempts)
            {
                hintTextBlock.Text = $"К сожалению, у вас закончились попытки. Загаданное число было {_randomNumber}.";
                guessTextBox.IsEnabled = false;
                return;
            }


            if (guess < _randomNumber)
            {
                hintTextBlock.Text = "Слишком мало. Попробуйте число побольше.";
            }
            else
            {
                hintTextBlock.Text = "Слишком много. Попробуйте число поменьше.";
            }

            guessTextBox.Text = "";

        }

        private void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

            private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text[0]))
            {
                e.Handled = true;
            }
        }
    }
}
