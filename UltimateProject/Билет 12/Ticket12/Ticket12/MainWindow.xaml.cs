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

namespace Ticket12
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

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender == widthSlider)
            {
                AnimateRectangle(animatedRectangle, Rectangle.WidthProperty, e.NewValue);
            }
            else if (sender == heightSlider)
            {
                AnimateRectangle(animatedRectangle, Rectangle.HeightProperty, e.NewValue);
            }
        }

        private void AnimateRectangle(Rectangle rectangle, DependencyProperty property, double targetValue)
        {
            var animation = new DoubleAnimation
            {
                To = targetValue,
                Duration = new Duration(System.TimeSpan.FromSeconds(0.3)),
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut }
            };
            if(rectangle != null)
                rectangle.BeginAnimation(property, animation);
        }
    }
}
