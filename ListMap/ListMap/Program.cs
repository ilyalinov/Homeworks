using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMap
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Insert(2);
            var modifier = new MapClass.Modifier(MapClass.ListElementModifier);
            MapClass.Map(list, modifier);
            list.Print();
        }
    }
}
