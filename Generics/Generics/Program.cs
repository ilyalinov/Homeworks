using System;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Insert(i);
            }
            foreach(var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
