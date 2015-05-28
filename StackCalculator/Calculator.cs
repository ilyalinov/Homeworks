using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    static class Calculator
    {
        /// <summary>
        /// Is given key an operand?
        /// </summary>
        /// <param name="key"> given key </param>
        /// <returns> 1 - operand, 0 - not operand </returns>
        private static bool IsOperand(char key)
        {
            return ((int)key >= (int)'0' && (int)key <= (int)'9');
        }

        /// <summary>
        /// Is given key an operation? 
        /// </summary>
        /// <param name="key"> Given key </param>
        /// <returns> 1 - operation, 0 - not operation </returns>
        private static bool IsOperation(char key)
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
        public static int Calculate(AbstractStack stack)
        {
            Console.WriteLine("Enter your arithmetic expression in postfix notation:");
            string expression = Console.ReadLine();

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

    }
}
