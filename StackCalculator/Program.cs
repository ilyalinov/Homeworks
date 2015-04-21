using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    class Program
    {
        
        static void Main(string[] args)
        {
             var stack = new ReferenceStack();
             /// <code>
             /// var stack = new ArrayStack();
             /// </code>
            Console.WriteLine("Result: " + Calculator.Calculate(stack));
        }
    }
}
