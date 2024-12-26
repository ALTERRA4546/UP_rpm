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

namespace Ticket11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ListBox _dragSource;

        public MainWindow()
        {
            InitializeComponent();
            listBox1.Items.Add("Item 1");
            listBox1.Items.Add("Item 2");
            listBox1.Items.Add("Item 3");

            listBox2.Items.Add("Item 4");
            listBox2.Items.Add("Item 5");
        }

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _dragSource = (ListBox)sender;

            if (_dragSource.SelectedItem != null)
            {
                DragDrop.DoDragDrop(_dragSource, _dragSource.SelectedItem, DragDropEffects.Move);
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            ListBox targetListBox = (ListBox)sender;

            if (e.Data.GetDataPresent(typeof(string)))
            {
                string draggedItem = (string)e.Data.GetData(typeof(string));
                if (draggedItem != null && _dragSource != targetListBox)
                {
                    targetListBox.Items.Add(draggedItem);
                    _dragSource.Items.Remove(draggedItem);
                }
            }
        }
    }
}
