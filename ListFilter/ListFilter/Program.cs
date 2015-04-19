using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            List list = new List();
            list.Insert(1);
            var modifier = new FilterClass.Modifier(FilterClass.ListElementFilter);
            list = FilterClass.Filter(list, modifier);
            list.Print();
        }
    }
}
