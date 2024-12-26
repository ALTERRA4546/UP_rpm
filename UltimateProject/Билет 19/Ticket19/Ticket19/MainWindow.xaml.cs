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
using System.Windows.Threading;

namespace Ticket19
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double ballXSpeed = 10;  // Скорость по оси X
        private double ballYSpeed = 8;  // Скорость по оси Y
        private double ballX;
        private double ballY;
        private DispatcherTimer timer;
        private Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();

            ballX = Canvas.GetLeft(ball);
            ballY = Canvas.GetTop(ball);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(16); // Частота обновления анимации
                timer.Tick += Timer_Tick;
                timer.Start();

                // Задаём случайное направление движения
                ballXSpeed = (random.NextDouble() > 0.5 ? 1 : -1) * (random.Next(1, 4));
                ballYSpeed = (random.NextDouble() > 0.5 ? 1 : -1) * (random.Next(1, 4));
            }
            else
            {
                timer.Stop();
                timer = null;
            }


        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Получаем текущие координаты мяча
            ballX = Canvas.GetLeft(ball);
            ballY = Canvas.GetTop(ball);

            // Обновляем позицию мяча
            ballX += ballXSpeed;
            ballY += ballYSpeed;

            // Проверяем столкновение со стенами
            if (ballX + ball.Width > canvas.ActualWidth || ballX < 0)
            {
                ballXSpeed *= -1; // Меняем направление по X
            }
            if (ballY + ball.Height > canvas.ActualHeight || ballY < 0)
            {
                ballYSpeed *= -1; // Меняем направление по Y
            }

            Canvas.SetLeft(ball, ballX);
            Canvas.SetTop(ball, ballY);
        }
    }
}
