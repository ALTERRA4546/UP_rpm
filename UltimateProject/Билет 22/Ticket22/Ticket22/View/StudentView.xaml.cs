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
using System.Windows.Shapes;
using Ticket22.ViewModel;

namespace Ticket22.View
{
    /// <summary>
    /// Логика взаимодействия для StudentView.xaml
    /// </summary>
    public partial class StudentView : Window
    {
        public StudentView()
        {
            InitializeComponent();
        }

        private void ClearFilterButton_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (StudentViewModel)DataContext;
            viewModel.ClearFilter();
        }
    }
}
