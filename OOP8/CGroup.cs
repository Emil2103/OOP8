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
using System.IO;

namespace OOP8
{
    class CGroup : Object
    {
        protected int maxcount;
        public int count;
        public Storage Stor;

        public CGroup()
        {
            id = ID;
            ++ID;
            code = 'G';
            selected = true;
        }

        public CGroup(int maxcount)
        {
            id = ID;
            ++ID;
            code = 'G';
            this.maxcount = maxcount;
            count = 0;
            Stor = new Storage(maxcount);
            selected = true;

        }
        ~CGroup()
        {
            for (int i = 0; i < maxcount; i++)
                Stor = null;
            Stor = null;
            --ID;
        }

        public bool addShape(Object obj)
        {
            if (count >= maxcount)
                return false;
            obj.setFlag(true);
            count++;
            Stor.obj[count - 1] = obj;
            return true;
        }
        public override void createShape() { }

        public int Count()
        {
            return count;
        }

        public override void DrawShape(Graphics G)
        {

            for (int i = 0; i < count; i++)
            {
                Stor.obj[i].DrawShape(G);
            }

        }

        public override void Move(int dx, int dy)
        {

            for (int i = 0; i < count; i++)
            {
                Stor.obj[i].Move(dx, dy);
            }
            outOfBounds();
        }

        public override void ObjSize(int dx)
        {
            for (int i = 0; i < count; i++)
            {
                Stor.obj[i].ObjSize(dx);
            }
            outOfBounds();
        }

        public override bool Popal(int x, int y)
        {
            for (int i = 0; i < count; i++)
            {
                if (Stor.obj[i].Popal(x, y))
                {
                    return true;
                }
            }
            return false;
        }

        public override void setSelect(bool a)
        {
            selected = a;
            for (int i = 0; i < count; i++)
            {
                if (Stor.obj[i] != null)
                    Stor.obj[i].setSelect(a);
            }

            if (!flag)
            {
                notifyEveryone();
            }
        }

        public override void ChangeColor(Color color)
        {
            for (int i = 0; i < count; i++)
                Stor.obj[i].ChangeColor(color);
        }

        public override void outOfBounds()
        {
            if (flag == false)
            {
                while (!CheckCircuit())
                {
                    RectangleF Rec = myPath.GetBounds();
                    PointF LeftTop = Rec.Location;
                    PointF RightTop = new PointF(Rec.Right, Rec.Top);
                    PointF LeftBottom = new PointF(Rec.Left, Rec.Bottom);
                    PointF RightBottom = new PointF(Rec.Right, Rec.Bottom);
                    if (!circuit.Contains(LeftTop) && !circuit.Contains(LeftBottom))
                        Move(1, 0);
                    if (!circuit.Contains(LeftTop) && !circuit.Contains(RightTop))
                        Move(0, 1);
                    if (!circuit.Contains(RightTop) && !circuit.Contains(RightBottom))
                        Move(-1, 0);
                    if (!circuit.Contains(LeftBottom) && !circuit.Contains(RightBottom))
                        Move(0, -1);
                }
            }
        }

        public override bool CheckCircuit()
        {
            for (int i = 0; i < count; i++)
            {
                if (!Stor.obj[i].CheckCircuit())
                {
                    myPath = Stor.obj[i].getPath();
                    return false;
                }
            }
            return true;
        }
        public override void setRectangleF(RectangleF value)
        {
            circuit = value;
            for (int i = 0; i < count; i++)
            {
                Stor.obj[i].setRectangleF(value);
            }
        }

        public Object[] Ungroup()
        {
            for (int i = 0; i < count; i++)
            {
                Stor.obj[i].setFlag(false);
            }

            return Stor.obj;

        }

        public override void save(StreamWriter writer)
        {
            writer.WriteLine(code);
            writer.WriteLine("maxcount " + maxcount.ToString());
            writer.WriteLine("count " + count.ToString());
            writer.WriteLine("Flag " + flag.ToString());
            for (int i = 0; i < count; ++i)
                Stor.obj[i].save(writer);
            writer.WriteLine();
        }

        public void loadGroup(StreamReader reader, ObjectFactory factory)
        {
            maxcount = int.Parse(extractInfo(reader.ReadLine()));
            Stor = new Storage(maxcount);
            count = int.Parse(extractInfo(reader.ReadLine()));
            flag = bool.Parse(extractInfo(reader.ReadLine()));
            Stor.loadShapes(reader, factory);
            for (int i = 0; i < count; ++i)
                this.circuit = Stor.obj[i].getCircuit();
        }

        public Storage getShape()
        {
            return Stor;
        }

        public override bool IntersectionShapes(GraphicsPath pth)
        {
            for(int i =0; i < count; i++)
            {
                if (Stor.obj[i].IntersectionShapes(pth))
                    return true;
            }
            return false;
        }
    }
}
