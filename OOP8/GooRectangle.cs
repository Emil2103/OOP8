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
    public class GooRectangle : CRectangle
    {
        public int deltaX = 0, deltaY = 0;
        protected bool gooFlag = false;

        public GooRectangle() : base()
        {
            code = 'A';

        }

        public GooRectangle(int x, int y, RectangleF circuit, Color color) : base(x, y, circuit, color)
        {
            code = 'A';
        }

        public override void onSubjectChanged(ISubject subject)
        {
            if (subject is Storage)
            {
                Storage shapes = (subject as Storage);
                for (int i = 0; i < shapes.getsize(); i++)
                {
                    if ( shapes.obj[i]!= null && shapes.obj[i].IntersectionShapes(myPath) && !observers.Contains(shapes.obj[i]) && shapes.obj[i] != this)
                        addObserver(shapes.obj[i]);
                    else
                        if (shapes.obj[i] != null && !shapes.obj[i].IntersectionShapes(myPath) && observers.Contains(shapes.obj[i]))
                        observers.Remove(shapes.obj[i]);
                }
                return;
            }

            if (subject is GooRectangle)
            {
                gooFlag = true;
                Move((subject as GooRectangle).deltaX, (subject as GooRectangle).deltaY);
                gooFlag = false;
            }
        }

        public override void Move(int dx, int dy)
        {
            int _x = x;
            int _y = y;
            x += dx;
            y += dy;
            createShape();
            outOfBounds();
            deltaX = x - _x;
            deltaY = y - _y;
            if (!flag && !gooFlag)
                notifyEveryone();
            deltaX = 0;
            deltaY = 0;
        }

        ~GooRectangle()
        {

        }

    }
}
