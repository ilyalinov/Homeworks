using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListNamespace
{

    class Program
    {
        /// <summary>
        /// Prints menu to console
        /// </summary>
        static void ShowMenu()
        {
            Console.WriteLine("1 - Insert key to the list");
            Console.WriteLine("2 - Delete element by its key");
            Console.WriteLine("3 - Find list element by key");
            Console.WriteLine("4 - Print list size to console");
            Console.WriteLine("5 - Print whole list to console");
            Console.WriteLine("Other number - exit");
        }

        /// <summary>
        /// Main program method
        /// </summary>
        /// <param name="args"> Main array of arguments </param>
        static void Main(string[] args)
        {
            List list = new List();
            while (true)
            {
                ShowMenu();
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        int key = Convert.ToInt32(Console.ReadLine());
                        list.Insert(key);
                        break;
                    case 2:
                        int key1 = Convert.ToInt32(Console.ReadLine());
                        list.Delete(key1);
                        break;
                    case 3:
                        int key2 = Convert.ToInt32(Console.ReadLine());
                        if (list.Search(key2))
                        {
                            Console.WriteLine("This element exists in your list");
                        }
                        else
                        {
                            Console.WriteLine("This element doesn't exist");
                        }
                        break;
                    case 4:
                        Console.WriteLine("List size: {0}", list.Size());
                        break;
                    case 5:
                        list.Print();
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
