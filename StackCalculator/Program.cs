using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    class Program
    {
        /// <summary>
        /// Is given key an operand?
        /// </summary>
        /// <param name="key"> given key </param>
        /// <returns> 1 - operand, 0 - not operand </returns>
        static bool IsOperand(char key)
        {
            return ((int) key >= (int) '0' && (int) key <= (int) '9');
        }

        /// <summary>
        /// Is given key an operation? 
        /// </summary>
        /// <param name="key"> Given key </param>
        /// <returns> 1 - operation, 0 - not operation </returns>
        static bool IsOperation(char key)
        {
            switch (key)
            {
                case '+':
                    return true;
                case '-':
                    return true;
                case '/':
                    return true;
                case '*':
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Calculates an expression in a postfix notation
        /// </summary>
        /// <returns> Answer </returns>
        /// /// <remarks>
        /// You can't switch stacks implementation uncommenting strings 52-54 and commenting string 51
        /// </remarks>
        static int Calculator()
        {
            Console.WriteLine("Enter your arithmetic expression in postfix notation:");
            string expression = Console.ReadLine();
            var stack = new ReferenceStack();
            /// <code>
            /// var stack = new ArrayStack();
            /// </code>

            foreach (var key in expression)
            {
                if (IsOperation(key))
                {
                    int operand1 = stack.Pop();
                    int operand2 = stack.Pop();
                    switch (key)
                    {
                        case '+':
                            stack.Push(operand2 + operand1);
                            break;
                        case '-':
                            stack.Push(operand2 - operand1);
                            break;
                        case '*':
                            stack.Push(operand2 * operand1);
                            break;
                        case '/':
                            stack.Push(operand2 / operand1);
                            break;
                    }
                }
                else if (IsOperand(key))
                {
                    stack.Push((int)Char.GetNumericValue(key));
                }
            }
            return stack.Pop();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Result: " + Calculator());
        }
    }
}
