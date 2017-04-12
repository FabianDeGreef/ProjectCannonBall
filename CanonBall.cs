using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Oef10_0KogelBaan
{
    public class CanonBall
    {
        private Canvas world;
        private int size = 20;
        private Ellipse canonBall;

        public CanonBall(Canvas world)
        {
            this.world = world;
        }

        public void drawCanonBall()
        {
            canonBall = new Ellipse();
            canonBall.Height = size;
            canonBall.Width = size;
            canonBall.Stroke = new SolidColorBrush(Colors.Red);
            canonBall.Fill = new SolidColorBrush(Colors.Red);
            canonBall.Margin = new Thickness(0, world.Height - 80, 0, 0);
            world.Children.Add(canonBall);
        }
        public void Update(int meterSeconden, int seconden, int angle)
        {
            meterSeconden = meterSeconden * 5;
            double radialen = (angle * Math.PI) / 180;

            // Horizontale afgelegde afstand in meters
            double horizontalMeter = meterSeconden * Math.Cos(radialen) * seconden;

            // Veritcaal afgelegde afstand in meters
            double verticalMeter = (meterSeconden * Math.Sin(radialen) * seconden) - (9.81 * (meterSeconden / (Math.Pow(seconden, 2))))/2* Math.Pow(seconden, 2);

            canonBall.Margin = new Thickness(horizontalMeter+canonBall.Margin.Left, canonBall.Margin.Top + (verticalMeter), 0, 0);
        }

        public void OutDistance()
        {
                canonBall.Margin = new Thickness(1500-size, 600-size, 0, 0);
        }
        public void GroundHit()
        {
            canonBall.Margin = new Thickness(canonBall.Margin.Left - size, 600 - size, 0, 0);
        }

        public double With
        { get
            {
                return canonBall.Margin.Left;
            }
        }

        public double Height
        {
            get
            {
                return -canonBall.Margin.Top+600+80;
            }
        }
    }
}
