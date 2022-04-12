using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCOILaba1.Structures
{
    public class Circle
    {
        public int x { get; set; }
        public int y { get; set; }

        public Pen pen { get; set; }
        public int radius { get; set; }

        public bool IsSelected { get; set; }= false;

        public Circle(int X,int Y,Pen Pen,int Radius)
        {
            x = X;
            y = Y;
            pen = Pen;
            radius = Radius;
        }
    }
}
