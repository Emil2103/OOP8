using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOP8
{
    class Storage
    {
        public int count;
        public int size;
        public Object[] obj;



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
                    count++;
                    break;
                }
            }

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
            }
        }
        public int getsize()
        {
            return size;
        }


        public void SaveObject(string pathToTheFile)
        {
            if (count != 0)
            {
                using (StreamWriter writer = new StreamWriter(pathToTheFile, false, System.Text.Encoding.Default))
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (obj[i] != null)
                            obj[i].save(writer);
                    }
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
                    if (shape is CGroup)
                    {
                        (shape as CGroup).loadGroup(reader, factory);
                        addObject(shape);
                        continue;
                    }

                    shape.load(reader);
                    addObject(shape);
                }
                else
                {
                    return;
                }
            }
        }

        public void loadShapes(string pathToTheFile, ObjectFactory factory)
        {
            using (StreamReader reader = new StreamReader(pathToTheFile, System.Text.Encoding.Default))
            {
                readingShapes(reader, factory);

            }
        }

        public void loadShapes(StreamReader reader, ObjectFactory factory)
        {
            readingShapes(reader, factory);
        }
    }
}
