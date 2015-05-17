using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueNamespace
{
    class Program
    {
        /// <summary>
        /// Prints menu to console
        /// </summary>
        static void ShowMenu()
        {
            Console.WriteLine("1 - Insert key to the queue");
            Console.WriteLine("2 - Delete first element");
            Console.WriteLine("3 - Print queue size to console");
            Console.WriteLine("Other number - exit");
        }

        static void Main(string[] args)
        {
            var queue = new QueueClass();
            while (true)
            {
                ShowMenu();
                int userChoice = Convert.ToInt32(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Enter element key: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter element priority: ");
                        int priority = Convert.ToInt32(Console.ReadLine());
                        queue.Enqueue(key, priority);
                        break;
                    case 2:
                        try
                        {
                            int key1 = queue.Dequeue();
                            Console.WriteLine("Deleted element with key: {0}", key1);
                        }
                        catch(NullReferenceException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3:
                        Console.WriteLine("size: {0}", queue.Size);
                        break;
                    default:
                        return;
                }
            }
        }
    }
}
