using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Ticket6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Phone> Phones { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Phones = new ObservableCollection<Phone>
        {
            new Phone {Id=1, ImagePath="/Image/image.png", Title="iPhone 6S", Company="Apple" },
            new Phone {Id=2, ImagePath="/Image/image.png", Title="Lumia 950", Company="Microsoft" },
            new Phone {Id=3, ImagePath="/Image/image.png", Title="Nexus 5X", Company="Google" },
            new Phone {Id=4, ImagePath="/Image/image.png", Title="Galaxy S6", Company="Samsung"}
        };
            phonesList.ItemsSource = Phones;
        }

        public class Phone
        {
            public int Id { get; set; }
            public string Title { get; set; } // модель телефона
            public string Company { get; set; } // производитель
            public string ImagePath { get; set; } // путь к изображению
        }
    }
}
