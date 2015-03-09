using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    class Program
    {
        static bool IsOperand(char key)
        {
            return ((int) key >= (int) '0' && (int) key <= (int) '9');
        }

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

        static int Calculator()
        {
            Console.WriteLine("Enter your arithmetic expression in postfix notation:");
            string expression = Console.ReadLine();
            var stack = new ReferenceStack();

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
