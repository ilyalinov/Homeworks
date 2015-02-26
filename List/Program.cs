using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            ListElement listElement1 = new ListElement(3);
            list.Insert(listElement1);
            Console.WriteLine(list.Delete(listElement1));
        }
    }
}
