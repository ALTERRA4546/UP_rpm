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

namespace Ticket4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow = null;

        public Window1()
        {
            InitializeComponent();
            mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        }

        public void UpdateMessage()
        {
            DataFromMainTextBlock.Text = TransferData.Message;
        }

        private void ChildTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransferData.Message = ChildTextBox.Text;
            mainWindow.UpdateMessage();
        }
    }
}
