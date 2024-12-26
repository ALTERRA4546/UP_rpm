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

namespace Ticket4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Window1 window1Sender = null;

        public MainWindow()
        {
            InitializeComponent();
            Window1 window1 = new Window1();
            window1.Show();

            window1Sender = Application.Current.Windows.OfType<Window1>().FirstOrDefault();
        }

        public void UpdateMessage()
        {
            DataFromChildTextBlock.Text = TransferData.Message;
        }

        private void MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TransferData.Message = MainTextBox.Text;
            if (window1Sender != null)
            {
                window1Sender.UpdateMessage();
            }
        }
    }
}
