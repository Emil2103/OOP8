using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace OOP8
{
    class CTriangle : Object
    {
        public CTriangle()
        {
            id = ID;
            ++ID;
            code = 'T';

        }
        public CTriangle(int x, int y, RectangleF circuit, Color color)
        {
            id = ID;
            ++ID;
            code = 'T';
            this.x = x;
            this.y = y;
            this.circuit = circuit;
            this.color = color;
            createShape();
            outOfBounds();
        }

        public override void createShape()
        {
            myPath.Reset();
            Point[] point = new Point[]
            {
                new Point(x, y - OValue/2),
                new Point(x-OValue/2, y + OValue/2),
                new Point(x + OValue/2, y + OValue/2)
            };
            myPath.AddPolygon(point);
        }

        ~CTriangle()
        {
            --ID;
        }
    }
}
