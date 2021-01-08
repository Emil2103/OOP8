using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP8
{
    class Storage: IObserver, ISubject
    {
        public int count;
        public int size;
        public Object[] obj;
        private List<IObserver> observers = new List<IObserver>();


        public Storage(int size)
        {
            this.size = size;
            count = 0;
            obj = new Object[size];
            for (int i = 0; i < size; i++)
            {
                obj[i] = null;

            }
        }

        public void addObject(Object t)
        {
            for (int i = 0; i < size; i++)
            {
                if (obj[i] == null)
                {
                    obj[i] = t;
                    if (t is GooRectangle)
                    {
                        addObserver(t);
                    }
                    t.addObserver(this);
                    count++;
                    break;
                }
            }
            notifyEveryone();

        }

        public Object getObject(int i)
        {
            return obj[i];
        }

        public void increaseSize(int newsize)
        {
            Object[] NewObj = new Object[size + newsize];
            for (int i = 0; i < size + newsize; i++)
                NewObj[i] = null;

            for (int i = 0; i < size; i++)
                if (obj[i] != null)
                    NewObj[i] = obj[i];
            obj = NewObj;
            size += newsize;
        }

        public void deleteObject(int i)
        {
            if (obj[i] != null)
            {
                obj[i] = null;
                count--;
                for (int j = i; j < size-1; j++)
                    if (obj[j + 1] != null)
                    {
                        obj[j] = obj[j + 1];
                        obj[j + 1] = null; 
                    }
                
            }
            notifyEveryone();

        }
        public int getsize()
        {
            return size;
        }


        public void SaveObject(StreamWriter writer)
        {
            if (count != 0)
            {

                for (int i = 0; i < count; i++)
                {
                    if (obj[i] != null)
                        obj[i].save(writer);
                }

            }
        }

        private void readingShapes(StreamReader reader, ObjectFactory factory)
        {
            string line;
            while ((line = reader.ReadLine()) != null && line != "")
            {
                char code = line[0];
                Object shape = factory.createShape(code);

                if (shape != null)
                {
                    shape.load(reader);
                    addObject(shape);
                }
                else
                {
                    return;
                }
            }
        }

        public void loadShapes(StreamReader reader, ObjectFactory factory)
        {
            readingShapes(reader, factory);
        }

        public bool Contains(int id)
        {
            int i = 0;
                while ( i != count && obj[i].getID() != id)
                {
                    if (obj[i] is CGroup)
                    {
                        return (obj[i] as CGroup).getShape().Contains(id);  
                    }
                    i++;
                }

            if (i != count)
                return true;
            else
                return false;

            
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
            for (int i = 0; i < observers.Count; i++)
                observers[i].onSubjectChanged(this);
        }

        public void onSubjectChanged(ISubject subject)
        {
            int i = 0;
            if (subject is MyTreeView)
            {
                while (i != getsize())
                {
                    Object _obj = obj[i];
                    if (_obj != null && _obj.getID() == (subject as MyTreeView).selected)
                    {
                        break;
                    }
                    else
                    {
                        if (_obj is CGroup)
                        {
                            if ((_obj as CGroup).getShape().Contains((subject as MyTreeView).selected) == true)
                                break;
                        }
                    }
                    i++;
                }

                if (obj[i] != null)
                {
                    Object _object = obj[i];
                    bool tmp = _object.getFlag();
                    _object.setFlag(true);
                    _object.setSelect((_object.getSelect() == true ? false : true));
                    _object.setFlag(tmp);
                }
                return;
            }
            notifyEveryone();
        }


    }
}
