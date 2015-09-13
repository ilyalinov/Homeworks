using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        static void ShowMenu()
        {
            Console.WriteLine("Type a number of the operation");
            Console.WriteLine("1 - push");
            Console.WriteLine("2 - pop");
            Console.WriteLine("3 - check stack on emptiness");
            Console.WriteLine("4 - print the number of elements");
            Console.WriteLine("Other number - exit");
        }

        static void Main(string[] args)
        {
            Stack stack = new Stack();
            while (true)
            {
                ShowMenu();
                int userChoice = Convert.ToInt16(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Type your number: ");
                        int key = Convert.ToInt32(Console.ReadLine());
                        stack.Push(key);
                        break;
                    case 2:
                        try
                        {
                            stack.Pop();
                        }
                        catch (Exception e)
                        {
                            System.Console.WriteLine(e.Message);
                            throw;
                        }
                        break;
                    case 3:
                        if (stack.IsEmpty())
                        {
                            Console.WriteLine("Stack is empty");
                        }
                        else
                        {
                            Console.WriteLine("Stack isn't empty");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Number of stack elements: {0}", stack.GetElemsQuantity());
                        break;
                    default:
                        return;   
                }
            }
        }
    }
}
