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

namespace Ticket24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=JKH_Database;Integrated Security=True;"; // Замените на свои параметры подключения

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string fullNameFilter = FullNameTextBox.Text.Trim();
            string streetFilter = StreetTextBox.Text.Trim();

            try
            {
                List<JKHAccount> results = GetAccounts(fullNameFilter, streetFilter);
                ResultsDataGrid.ItemsSource = results;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private List<JKHAccount> GetAccounts(string fullNameFilter, string streetFilter)
        {
            List<JKHAccount> accounts = new List<JKHAccount>();

            string sqlQuery = "SELECT ID, Street, Apartment, FullName, Account FROM JKH_Accounts WHERE 1=1";

            if (!string.IsNullOrEmpty(fullNameFilter))
            {
                sqlQuery += " AND FullName LIKE @FullName";
            }
            if (!string.IsNullOrEmpty(streetFilter))
            {
                sqlQuery += " AND Street LIKE @Street";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    if (!string.IsNullOrEmpty(fullNameFilter))
                    {
                        command.Parameters.AddWithValue("@FullName", "%" + fullNameFilter + "%");
                    }
                    if (!string.IsNullOrEmpty(streetFilter))
                    {
                        command.Parameters.AddWithValue("@Street", "%" + streetFilter + "%");
                    }

                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new JKHAccount
                            {
                                ID = (int)reader["ID"],
                                Street = reader["Street"].ToString(),
                                Apartment = reader["Apartment"].ToString(),
                                FullName = reader["FullName"].ToString(),
                                Account = (decimal)reader["Account"]
                            });
                        }
                    }
                }
            }

            return accounts;
        }
    }

    public class JKHAccount
    {
        public int ID { get; set; }
        public string Street { get; set; }
        public string Apartment { get; set; }
        public string FullName { get; set; }
        public decimal Account { get; set; }
    }
}
