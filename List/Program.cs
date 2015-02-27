using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("1 - Insert key to the list");
            Console.WriteLine("2 - Delete element by its key");
            Console.WriteLine("3 - Find list element by key");
            Console.WriteLine("4 - Print list size to console");
            Console.WriteLine("5 - Print whole list to console");
            Console.WriteLine("Other number - exit");
        }
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
                        ListElement newElement = new ListElement(key);
                        list.Insert(newElement);
                        break;
                    case 2:
                        int key1 = Convert.ToInt32(Console.ReadLine());
                        ListElement listElement = list.Search(key1);
                        if (listElement == null)
                        {
                            Console.WriteLine("No such element in your list");
                        }
                        else
                        {
                            Console.WriteLine("Deleted element with key: {0}", listElement.GetKey());
                            list.Delete(listElement);
                        }
                        break;
                    case 3:
                        int key2 = Convert.ToInt32(Console.ReadLine());
                        var temp = list.Search(key2);
                        if (temp == null)
                        {
                            Console.WriteLine("No such element in your list");
                        }
                        else
                        {
                            Console.WriteLine("Such element exists in your list");
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
