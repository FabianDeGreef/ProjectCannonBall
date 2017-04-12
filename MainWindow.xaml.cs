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

namespace Oef10_0KogelBaan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private World world;
        private CanonBall canonball;
        private DispatcherTimer timer;
        private int seconden = 0;
        public MainWindow()
        {
            InitializeComponent();
            labelAngle.Content = Convert.ToString((int)sliderAngle.Value);
            labelSpeed.Content = Convert.ToString((int)sliderSpeed.Value);
            world = new World(canvasWorld);
            world.drawMeters();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            canonball = new CanonBall(canvasWorld);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconden++;
            canonball.Update((int)sliderSpeed.Value, seconden, (int)sliderAngle.Value);
            labelDistanceMeter.Content = String.Format("{0:0.00}", canonball.With / 5);
            labelHeightMeter.Content = String.Format("{0:0.00}", canonball.Height / 5);
            if (canonball.With / 5 >= 300)
            {
                timer.Stop();
                canonball.OutDistance();
                labelDistanceMeter.Content = String.Format("{0:0.00}", 300);
                labelHeightMeter.Content = String.Format("{0:0.00}", 0);
            }
            else if (canonball.Height / 5 <= 0)
            {
                timer.Stop();
                canonball.GroundHit();
                labelHeightMeter.Content = String.Format("{0:0.00}", 0);
            }
        }

        private void buttonShoot_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
            canonball.drawCanonBall();
            sliderAngle.IsEnabled = false;
            sliderSpeed.IsEnabled = false;
        }

        private void sliderSpeed_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelSpeed.Content = Convert.ToString((int)sliderSpeed.Value);
        }

        private void sliderAngle_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelAngle.Content = Convert.ToString((int)sliderAngle.Value);
        }
    }
}
