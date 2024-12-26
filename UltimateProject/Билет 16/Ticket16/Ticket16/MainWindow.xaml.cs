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

namespace Ticket16
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class Task
        {
            public string Name { get; set; }
            public string Status { get; set; }

            public Task(string name, string status)
            {
                Name = name;
                Status = status;
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            List<Task> tasks = new List<Task>()
            {
                new Task("Task 1","Completed"),
                new Task("Task 2", "Pending"),
                new Task("Task 3", "Failed"),
                new Task("Task 4", "Completed"),
                new Task("Task 5", "Pending"),
            };

            tasksListBox.ItemsSource = tasks;

        }
    }
}
