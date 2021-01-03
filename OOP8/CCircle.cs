using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP8
{
    class CCircle : Object
    {
        public CCircle()
        {
            id = ID;
            ++ID;
            code = 'C';

        }

        public CCircle(int x, int y, RectangleF circuit, Color color)
        {
            id = ID;
            ++ID;
            code = 'C';
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
            Rectangle PathRec = new Rectangle(x - OValue / 2, y - OValue / 2, OValue, OValue);
            myPath.AddEllipse(PathRec);
        }

        ~CCircle()
        {
            --ID;
        }
    }
}
