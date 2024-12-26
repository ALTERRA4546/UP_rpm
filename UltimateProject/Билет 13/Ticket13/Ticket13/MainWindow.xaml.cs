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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ticket13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isVisible = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToggleVisibility_Click(object sender, RoutedEventArgs e)
        {
            _isVisible = !_isVisible;
            AnimateOpacity(fadeTextBlock, _isVisible ? 1.0 : 0.0);
        }

        private void AnimateOpacity(UIElement element, double targetOpacity)
        {
            var animation = new DoubleAnimation
            {
                To = targetOpacity,
                Duration = new Duration(System.TimeSpan.FromSeconds(0.3)),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseInOut }

            };

            element.BeginAnimation(UIElement.OpacityProperty, animation);
        }
    }
}
