using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace vin65WS2.Utility
{
    public static class Utility
    {
        //DUMP PROPERTIES OF AN OBJECT
        public static void DumpProperties(Object obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("   {0}={1}", name, value);
            }
        }

        //??????????????????
        //DUMP PROPERTIES OF AN OBJECT (with nested child properties)
        public static void DumpProperties2(Object obj)
        {
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(obj))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(obj);
                Console.WriteLine("   {0}={1}", name, value);

                //access child properties
                if (descriptor.PropertyType.IsArray)
                {
                    var mychild = descriptor.GetChildProperties();
                    Console.Write("   ");              //indent
                    for (int i = 0; i < mychild.Count; i++)
                    {
                        string childname = mychild[i].Name;
                        object childvalue = mychild[i].GetValue(mychild);
                        //Console.WriteLine("...{0}=", childname);
                        Console.WriteLine("...{0}={1}", childname, childvalue);
                    }
                    //foreach(Object o in mychild)
                    //{
                    //    Console.WriteLine("..." + o);
                    //}
                    //DumpProperties2(mychild);       //recursive (calls itself)
                }
            }
        }

    }
}
