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

namespace Ticket9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> Products { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Products = new ObservableCollection<Product>();
            productDataGrid.DataContext = this;
            Products.Add(new Product("Laptop", 1200, 5));
            Products.Add(new Product("Mouse", 25, 20));
            Products.Add(new Product("Keyboard", 75, 10));
            productDataGrid.ItemsSource = Products;
        }

        public class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            public Product(string name, decimal price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }
            public Product()
            {

            }
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            Products.Add(new Product());
            productDataGrid.SelectedItem = Products[Products.Count - 1];
            productDataGrid.BeginEdit();

        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (productDataGrid.SelectedItem != null)
            {
                Products.Remove((Product)productDataGrid.SelectedItem);
            }
        }
    }
}
