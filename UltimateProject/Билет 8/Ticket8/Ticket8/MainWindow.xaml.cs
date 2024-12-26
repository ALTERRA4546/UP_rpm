using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Ticket8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Abiturient> abiturients = new List<Abiturient>();
        private const char Separator = '|';

        public MainWindow()
        {
            InitializeComponent();
            AbiturientsDataGrid.ItemsSource = abiturients;
        }

        public class Abiturient
        {
            public string Surname { get; set; }
            public int Course { get; set; }
            public string Group { get; set; }
            public double AverageScore { get; set; }

            public Abiturient(string surname, int course, string group, double averageScore)
            {
                Surname = surname;
                Course = course;
                Group = group;
                AverageScore = averageScore;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string surname = SurnameTextBox.Text;
                int course = int.Parse(CourseTextBox.Text);
                string group = GroupTextBox.Text;
                double averageScore = double.Parse(AverageScoreTextBox.Text);

                Abiturient abiturient = new Abiturient(surname, course, group, averageScore);
                abiturients.Add(abiturient);
                AbiturientsDataGrid.Items.Refresh();
                ClearInputFields();
            }
            catch (FormatException)
            {
                MessageBox.Show("Некорректный формат данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        foreach (var abiturient in abiturients)
                        {
                            string line = $"{abiturient.Surname}{Separator}" +
                                          $"{abiturient.Course}{Separator}" +
                                           $"{abiturient.Group}{Separator}" +
                                           $"{abiturient.AverageScore}";
                            writer.WriteLine(line);
                        }
                    }
                    MessageBox.Show("Ведомость сохранена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка сохранения файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    abiturients.Clear();
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] parts = line.Split(Separator);
                            if (parts.Length == 4)
                            {
                                string surname = parts[0];
                                int course = int.Parse(parts[1]);
                                string group = parts[2];
                                double averageScore = double.Parse(parts[3]);
                                abiturients.Add(new Abiturient(surname, course, group, averageScore));
                            }
                        }
                        AbiturientsDataGrid.Items.Refresh();
                        AbiturientsDataGrid.ItemsSource = abiturients;
                    }
                    MessageBox.Show("Ведомость загружена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка загрузки файла: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ClearInputFields()
        {
            SurnameTextBox.Clear();
            CourseTextBox.Clear();
            GroupTextBox.Clear();
            AverageScoreTextBox.Clear();
        }
    }
}
