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
    public abstract class Object : ISerializable, IObserver, ISubject
    {
        public int x;
        public int y;
        protected bool flag = false;
        protected int OValue = 50;
        protected RectangleF circuit;
        protected GraphicsPath myPath = new GraphicsPath();
        protected Color color;
        Pen redpen = new Pen(Color.Red);
        protected bool selected = false;

        protected int id;
        protected char code;
        public static int ID = 0;

        protected List<IObserver> observers = new List<IObserver>();

        public virtual void DrawShape(Graphics G)
        {
            Pen pen = new Pen(color, 2);
            redpen.Width = 2;
            G.DrawPath(selected ? redpen : pen, myPath);
        }

        public int getID()
        {
            return id;
        }

        public int getX()
        {
            return x;
        }

        public int getY()
        {
            return y;
        }

        public virtual bool Popal(int x, int y)
        {
            return myPath.IsVisible(x, y);
        }

        public virtual void ObjSize(int dx)
        {
            OValue = OValue + dx;
            createShape();
            if (!flag)
            {
                outOfBounds();
                notifyEveryone();
            }
        }

        public virtual void Move(int dx, int dy)
        {
            x = x + dx;
            y = y + dy;
            createShape();
            if (!flag)
            {
                outOfBounds();
                notifyEveryone();
            }
        }

        public abstract void createShape();

        public virtual void outOfBounds()
        {
            if (flag == false)
            {
                while (!CheckCircuit())
                {
                    RectangleF ShapeCircuit = myPath.GetBounds();
                    PointF LeftTop = ShapeCircuit.Location;
                    PointF RightTop = new PointF(ShapeCircuit.Right, ShapeCircuit.Top);
                    PointF LeftBottom = new PointF(ShapeCircuit.Left, ShapeCircuit.Bottom);
                    PointF RightBottom = new PointF(ShapeCircuit.Right, ShapeCircuit.Bottom);
                    if (!circuit.Contains(LeftTop) && !circuit.Contains(LeftBottom))
                        ++x;
                    if (!circuit.Contains(LeftTop) && !circuit.Contains(RightTop))
                        ++y;
                    if (!circuit.Contains(RightTop) && !circuit.Contains(RightBottom))
                        --x;
                    if (!circuit.Contains(LeftBottom) && !circuit.Contains(RightBottom))
                        --y;
                    createShape();
                }
            }
        }

        public virtual void ChangeColor(Color color)
        {
            this.color = color;
        }

        public virtual bool getSelect()
        {
            return selected;
        }

        public virtual void setSelect(bool value)
        {
            selected = value;
            if (!flag)
                notifyEveryone();
        }

        public virtual void setFlag(bool value)
        {
            flag = value;
        }

        public bool getFlag()
        {
            return flag;
        }

        public virtual void setRectangleF(RectangleF value)
        {
            circuit = value;
        }

        public virtual bool CheckCircuit()
        {
            return circuit.Contains(myPath.GetBounds());
        }

        public RectangleF getCircuit()
        {
            return circuit;
        }
        public GraphicsPath getPath()
        {
            return myPath;
        }

        public virtual void save(StreamWriter writer)
        {
            writer.WriteLine(code);
            writingCommonParams(writer);
        }

        public virtual void load(StreamReader reader)
        {
            readingCommonParams(reader);
            createShape();
        }

        protected string extractInfo(string line)
        {
            string[] parts = line.Split(' ');
            return parts[1];
        }

        public void writingCommonParams(StreamWriter writer)
        {
            float x = circuit.X;
            float y = circuit.Y;
            float height = circuit.Height;
            float width = circuit.Width;

            writer.WriteLine("RelocateFlag " + flag.ToString());
            writer.WriteLine("Selected " + selected.ToString());
            writer.WriteLine("Boarders:");
            writer.WriteLine("x " + x.ToString());
            writer.WriteLine("y " + y.ToString());
            writer.WriteLine("width " + width.ToString());
            writer.WriteLine("height " + height.ToString());
            writer.WriteLine("");
            writer.WriteLine("OValue " + OValue.ToString());
            writer.WriteLine("xShape " + this.x.ToString());
            writer.WriteLine("yShape " + this.y.ToString());
            string col = color.ToString().Substring(7);
            col = col.Remove(col.Length - 1);
            writer.WriteLine("color " + col);
        }

        public void readingCommonParams(StreamReader reader)
        {
            flag = bool.Parse(extractInfo(reader.ReadLine()));
            selected = bool.Parse(extractInfo(reader.ReadLine()));
            reader.ReadLine();
            float x = float.Parse(extractInfo(reader.ReadLine()));
            float y = float.Parse(extractInfo(reader.ReadLine()));
            float width = float.Parse(extractInfo(reader.ReadLine()));
            float height = float.Parse(extractInfo(reader.ReadLine()));
            circuit = new RectangleF(x, y, width, height);
            reader.ReadLine();
            OValue = int.Parse(extractInfo(reader.ReadLine()));
            this.x = int.Parse(extractInfo(reader.ReadLine()));
            this.y = int.Parse(extractInfo(reader.ReadLine()));
            switch (extractInfo(reader.ReadLine()))
            {
                case "Yellow":
                    {
                        color = Color.Yellow;
                        break;
                    }
                case "Blue":
                    {
                        color = Color.Blue;
                        break;
                    }
                case "Black":
                    {
                        color = Color.Black;
                        break;
                    }
            }

        }
        
        public void addObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void removeObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void notifyEveryone()
        {
            for (int i = 0; i < observers.Count(); i++)
                observers[i].onSubjectChanged(this);
        }

        public virtual void onSubjectChanged(ISubject subject)
        {
            if(subject is GooRectangle)
            {
                if (!flag)
                    Move((subject as GooRectangle).deltaX, (subject as GooRectangle).deltaY);
                else
                    subject.removeObserver(this);
            }
        }

        public virtual bool IntersectionShapes(GraphicsPath pth)
        {
            return myPath.GetBounds().IntersectsWith(pth.GetBounds());
        }
    }
}
