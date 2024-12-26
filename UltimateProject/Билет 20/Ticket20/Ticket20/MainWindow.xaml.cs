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
using static Ticket20.MainWindow;

namespace Ticket20
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

        public class Student
        {
            public string LastName { get; set; }
            public int Course { get; set; }
            public string RecordBookNumber { get; set; }

            public Student(string lastName, int course, string recordBookNumber)
            {
                LastName = lastName;
                Course = course;
                RecordBookNumber = recordBookNumber;
            }

            public virtual string Print()
            {
                return $"Фамилия: {LastName}, Курс: {Course}, Номер зачетки: {RecordBookNumber}";
            }
        }

        public class Aspirant : Student
        {
            public string DissertationTopic { get; set; }

            public Aspirant(string lastName, int course, string recordBookNumber, string dissertationTopic) : base(lastName, course, recordBookNumber)
            {
                DissertationTopic = dissertationTopic;
            }

            public override string Print()
            {
                base.Print();
                return $"Тема диссертации: {DissertationTopic}";
            }
        }

        private void CreateStudentButton_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student("Иванов", 3, "12345");
            outputTextBox.Text += "Информация о студенте:\n";
            
            outputTextBox.Text += student.Print()+ "\n";
        }

        private void CreateAspirantButton_Click(object sender, RoutedEventArgs e)
        {
            Aspirant aspirant = new Aspirant("Петров", 4, "67890", "Разработка нейронных сетей");
            outputTextBox.Text += "Информация об аспиранте:\n";
            outputTextBox.Text += aspirant.Print() + "\n";
        }
    }
}
