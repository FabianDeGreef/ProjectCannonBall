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
        private int size = 15;
        private Ellipse canonBall;

        public CanonBall(Canvas world)
        {
            this.world = world;
        }

        public void Update(int meterSeconden, int angle, int seconden)
        {
            // Schaal
            meterSeconden = meterSeconden * 5;

            // Radialen
            double radialen = Math.PI * angle / 180;

            // Horizontale afgelegde afstand in meters
            double horizontalMeter = meterSeconden * Math.Cos(radialen) * seconden;

            // Veritcaal afgelegde afstand in meters
            double verticalMeter = (meterSeconden * Math.Sin(radialen) * seconden) - (9.81 * (meterSeconden / (Math.Pow(seconden, 2)))) / 2 * Math.Pow(seconden, 2);


            canonBall.Margin = new Thickness(horizontalMeter, verticalMeter + world.Height, 0, 0);

            //canonBall.Margin = new Thickness(horizontalMeter+canonBall.Margin.Left, canonBall.Margin.Top + (verticalMeter), 0, 0);
        }
        public void GroundHit()
        {
            canonBall.Margin = new Thickness(canonBall.Margin.Left, world.Height - size, 0, 0);
        }

        public double With
        {
            get
            {
                return canonBall.Margin.Left + size / 2;
            }
        }

        public double Height
        {
            get
            {
                return -canonBall.Margin.Top + (world.Height - 80);
            }
        }
        public double Size
        {
            get
            {
                return size;
            }
        }

        public void drawCanonBall()
        {
            canonBall = new Ellipse();
            canonBall.Height = size;
            canonBall.Width = size;
            canonBall.Stroke = new SolidColorBrush(Colors.Red);
            canonBall.Fill = new SolidColorBrush(Colors.Red);
            canonBall.Margin = new Thickness(0, world.Height - 85, 0, 0);
            world.Children.Add(canonBall);
        }
    }
}
