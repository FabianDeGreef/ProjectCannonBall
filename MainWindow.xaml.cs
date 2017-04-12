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
            canonball = new CanonBall(canvasWorld);
            labelAngle.Content = Convert.ToString((int)sliderAngle.Value);
            labelSpeed.Content = Convert.ToString((int)sliderSpeed.Value);
            world = new World(canvasWorld);
            world.drawMeters();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(400);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            seconden++;
            canonball.Update((int)sliderSpeed.Value, (int)sliderAngle.Value, seconden);

            labelDistanceMeter.Content = String.Format("{0:0.00}", canonball.With / 5);
            labelHeightMeter.Content = String.Format("{0:0.00}", canonball.Height / 5);

            if (canonball.Height / 5 <= canonball.Size)
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
            buttonShoot.IsEnabled = false;
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
