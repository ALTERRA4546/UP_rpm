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

namespace Ticket10
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Car> Cars { get; set; }
        private List<Car> _originalCars;

        public MainWindow()
        {
            InitializeComponent();

            _originalCars = new List<Car>
            {
               new Car("Smith", "BMW", "Gasoline", 200, 60, 30, 4),
                new Car("Johnson", "Audi", "Diesel", 180, 70, 60, 5),
                new Car("Williams", "Mercedes", "Gasoline", 300, 80, 70, 6),
                 new Car("Brown", "Ford", "Electric", 150, 50, 50, 7),
                new Car("Davis", "Toyota", "Gasoline", 190, 65, 45, 4),
                 new Car("Miller", "Honda", "Hybrid", 170, 55, 35, 5),
                new Car("Wilson", "Nissan", "Diesel", 220, 75, 55, 6),
                new Car("Taylor", "Chevrolet", "Gasoline", 250, 70, 20, 7)
            };

            Cars = new ObservableCollection<Car>(_originalCars);
            carDataGrid.ItemsSource = Cars;
            DataContext = this;
        }

        public class Car
        {
            public string OwnerLastName { get; set; }
            public string CarMakeCode { get; set; }
            public string FuelType { get; set; }
            public int EnginePower { get; set; }
            public int TankVolume { get; set; }
            public int FuelLevel { get; set; }
            public int OilVolume { get; set; }
            public Car() { }

            public Car(string ownerLastName, string carMakeCode, string fuelType, int enginePower, int tankVolume, int fuelLevel, int oilVolume)
            {
                OwnerLastName = ownerLastName;
                CarMakeCode = carMakeCode;
                FuelType = fuelType;
                EnginePower = enginePower;
                TankVolume = tankVolume;
                FuelLevel = fuelLevel;
                OilVolume = oilVolume;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                Cars = new ObservableCollection<Car>(_originalCars);
                carDataGrid.ItemsSource = Cars;
            }
            else
            {
                var filteredCars = _originalCars.Where(car =>
                car.OwnerLastName.ToLower().Contains(searchText) ||
                car.CarMakeCode.ToLower().Contains(searchText) ||
                car.FuelType.ToLower().Contains(searchText) ||
                car.EnginePower.ToString().Contains(searchText)).ToList();
                Cars = new ObservableCollection<Car>(filteredCars);
                carDataGrid.ItemsSource = Cars;
            }

        }


        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.ToLower();

            var sortedCars = _originalCars.Where(car =>
                car.OwnerLastName.ToLower().Contains(searchText) ||
                car.CarMakeCode.ToLower().Contains(searchText) ||
                car.FuelType.ToLower().Contains(searchText) ||
                car.EnginePower.ToString().Contains(searchText)).OrderBy(car => car.OwnerLastName).ToList();
            Cars = new ObservableCollection<Car>(sortedCars);
            carDataGrid.ItemsSource = Cars;
        }
    }
}
