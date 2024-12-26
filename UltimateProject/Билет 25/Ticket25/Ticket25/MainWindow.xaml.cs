using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Ticket25
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=NotesDatabase;Integrated Security=True;";

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
        }

        private void LoadNotes()
        {
            try
            {
                List<Note> notes = GetNotes();
                NotesDataGrid.ItemsSource = notes;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<Note> GetNotes()
        {
            List<Note> notes = new List<Note>();
            string sqlQuery = "SELECT ID, DateTime, Title, Content FROM Notes";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            notes.Add(new Note
                            {
                                ID = (int)reader["ID"],
                                DateTime = (DateTime)reader["DateTime"],
                                Title = reader["Title"].ToString(),
                                Content = reader["Content"].ToString()
                            });
                        }
                    }
                }
            }
            return notes;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (NotesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Выберите заметку для удаления.", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Note selectedNote = (Note)NotesDataGrid.SelectedItem;

            try
            {
                DeleteNote(selectedNote.ID);
                MessageBox.Show("Заметка удалена.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                LoadNotes(); // Обновляем таблицу
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка удаления заметки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteNote(int id)
        {
            string sqlQuery = "DELETE FROM Notes WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    public class Note
    {
        public int ID { get; set; }
        public DateTime DateTime { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
