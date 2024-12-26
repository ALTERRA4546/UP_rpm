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

namespace Ticket3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var items = new List<MyObject>
            {
                new MyObject { Name = "Object 1", Value = 10 },
                new MyObject { Name = "Object 2", Value = 25 },
                new MyObject { Name = "Object 3", Value = 5 },
                new MyObject { Name = "Object 4", Value = 12 },
                new MyObject { Name = "Object 5", Value = 15 }
            };

            myListView.ItemsSource = items;
        }

        public class MyObject
        {
            public string Name { get; set; }
            public int Value { get; set; }
        }


    }
}
