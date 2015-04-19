using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFold
{
    class Program
    {
        static void Main(string[] args)
        {
            const int initialValue = 0;
            var list = new List();
            list.Insert(1);
            list.Insert(2);
            var updateValue = new FoldClass.UpdateValue(FoldClass.Sum);
            Console.WriteLine(FoldClass.Fold(list, initialValue, updateValue));
        }
    }
}
