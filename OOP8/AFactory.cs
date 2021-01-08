using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP8
{
    public abstract class ObjectFactory
    {
        public abstract Object createShape(char code);
    }

    public class MyObjectFactory : ObjectFactory
    {
        public override Object createShape(char code)
        {
            switch (code)
            {
                case 'C':
                    return new CCircle();
                case 'R':
                    return new CRectangle();
                case 'T':
                    return new CTriangle();
                case 'G':
                    return new CGroup();
                case 'A':
                    return new GooRectangle();
                default:
                    return null;
            }
        }
    }
}
