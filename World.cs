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
    public class World
    {
        private Canvas world;

        public World(Canvas world)
        {
            this.world = world;
        }

        public void DrawLines(int index)
        {
            Line line = new Line();
            // Punt1
            line.X1 = 50*(index+1);
            line.Y1 = world.Height;
            // Punt2
            line.X2 = line.X1;
            line.Y2 = world.Height-15;
            line.StrokeThickness = 1;
            line.Stroke = new SolidColorBrush(Colors.Black);
            world.Children.Add(line);
        }
        public void drawMeters()
        {
            for (int i = 0; i < (world.Width/50)-1;i++)
            {
                DrawLines(i);
            }
        }
    }
}
