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

namespace Ticket7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentFilePath;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                currentFilePath = openFileDialog.FileName;
                FilePathTextBlock.Text = $"Открытый файл: {currentFilePath}";
                try
                {
                    ContentTextBox.Text = File.ReadAllText(currentFilePath, Encoding.UTF8);
                    StatusTextBlock.Text = "Файл успешно открыт.";
                }
                catch (FileNotFoundException)
                {
                    StatusTextBlock.Text = "Ошибка: Файл не найден.";
                    ContentTextBox.Clear();
                }
                catch (IOException ex)
                {
                    StatusTextBlock.Text = $"Ошибка ввода-вывода: {ex.Message}";
                    ContentTextBox.Clear();
                }
                catch (Exception ex)
                {
                    StatusTextBlock.Text = $"Ошибка: {ex.Message}";
                    ContentTextBox.Clear();

                }
            }
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs();
            }
            else
            {
                SaveFile();
            }
        }
        private void SaveFile()
        {
            try
            {
                File.WriteAllText(currentFilePath, ContentTextBox.Text, Encoding.UTF8);
                StatusTextBlock.Text = "Файл успешно сохранен.";
            }
            catch (IOException ex)
            {
                StatusTextBlock.Text = $"Ошибка сохранения: {ex.Message}";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Ошибка: {ex.Message}";
            }
        }
        private void SaveFileAs_Click(object sender, RoutedEventArgs e)
        {
            SaveFileAs();
        }

        private void SaveFileAs()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                currentFilePath = saveFileDialog.FileName;
                FilePathTextBlock.Text = $"Открытый файл: {currentFilePath}";
                SaveFile();

            }
        }
    }
}
