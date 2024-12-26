using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Ticket23
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Book> _books;

        public MainWindow()
        {
            InitializeComponent();
            GenerateBooks();
        }

        private void GenerateBooks()
        {
            _books = new List<Book>();
            Random random = new Random();

            string[] authors = { "Автор1", "Автор2", "Автор3", "Автор4", "Автор5", "Автор6", "Автор7", "Автор8", "Автор9", "Автор10" };
            string[] titles = { "Книга1", "Книга2", "Книга3", "Книга4", "Книга5", "Книга6", "Книга7", "Книга8", "Книга9", "Книга10" };
            for (int i = 0; i < 50; i++)
            {
                _books.Add(new Book
                {
                    Title = titles[random.Next(0, titles.Length)] + (i + 1).ToString(),
                    Author = authors[random.Next(0, authors.Length)],
                    Year = random.Next(1900, 2024)
                });
            }
        }

        private void SimpleSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsDataGrid.ItemsSource = null;
            string searchText = SearchTextBox.Text.Trim();

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Book> results = SimpleSearch(searchText);
            stopwatch.Stop();

            ResultsDataGrid.ItemsSource = results;
            SimpleSearchTimeTextBlock.Text = stopwatch.Elapsed.ToString();
        }

        private List<Book> SimpleSearch(string searchText)
        {
            List<Book> searchResults = new List<Book>();
            foreach (var book in _books)
            {
                if (book.Author.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    searchResults.Add(book);
                }
            }
            return searchResults;
        }


        private void OptimizedSearchButton_Click(object sender, RoutedEventArgs e)
        {
            ResultsDataGrid.ItemsSource = null;
            string searchText = SearchTextBox.Text.Trim();

            Stopwatch stopwatch = Stopwatch.StartNew();
            List<Book> results = OptimizedSearch(searchText);
            stopwatch.Stop();

            ResultsDataGrid.ItemsSource = results;
            OptimizedSearchTimeTextBlock.Text = stopwatch.Elapsed.ToString();
        }

        private List<Book> OptimizedSearch(string searchText)
        {
            return _books.Where(book => book.Author.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
    }
}