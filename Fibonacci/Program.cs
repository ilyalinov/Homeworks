using System;

namespace Fibonacci
{
    class Program
    {
        private static int Fibonacci(int number)
        {
            int fib1 = 0;
            int fib2 = 1;
            int fibNext = 0;
            for (int i = 2; i <= number; i++)
            {
                fibNext = fib1 + fib2;
                fib1 = fib2;
                fib2 = fibNext;
            }
            if (number == 0)
            {
                return fib1;
            }
            else if (number == 1)
            {
                return fib2;
            }
            else
            {
                return fibNext;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your number >= 0 below: \n");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("{0} Fibonacci number: {1}\n", number, Fibonacci(number));
        }
    }
}
