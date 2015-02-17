using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorial
{
    class Program
    {
        static int Factorial(int number)
        {
            int result = 1;
            for (int i = 1; i <= number; i++)
            {
                result = result * i;
            }
            return result;
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your number >= 1 below: \n");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Result: {0}\n", Factorial(number));
        }
    }
}
