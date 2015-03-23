using System;

namespace TreeCalculator
{
    public static class ParseString
    {
        /// <summary>
        /// Divide expression on 2 operands and operation
        /// </summary>
        /// <param name="expression"> Given expression </param>
        /// <returns> 3 strings: operation and 2 operands; Returns only given expression if it's a simple operand </returns>
        static public string[] DivideOperand(string expression)
        {
            string[] result = new string[3];
            if (IsOperandComplex(expression))
            {
                result[0] += expression[2];
                int bracketsCounter = 0;
                int i = 4;
                while (bracketsCounter != 0 || expression[i] != ' ')
                {
                    if (expression[i] == '(')
                    {
                        bracketsCounter++;
                    }
                    else if(expression[i] == ')')
                    {
                        bracketsCounter--;
                    }
                    result[1] += expression[i];
                    i++;
                }

                i++;

                while (bracketsCounter != 0 || expression[i] != ' ')
                {
                    if (expression[i] == '(')
                    {
                        bracketsCounter++;
                    }
                    else if (expression[i] == ')')
                    {
                        bracketsCounter--;
                    }
                    result[2] += expression[i];
                    i++;
                }

                return result;
            }
            else
            {
                result[0] = expression;
                return result;
            }
        }

        /// <summary>
        /// Is operand complex? 
        /// </summary>
        /// <param name="expression"> operand </param>
        /// <returns> 1 - complex, 0 - simple </returns>
        static public bool IsOperandComplex(string expression)
        {
            return (expression[0] == '(');
        }
    }
}