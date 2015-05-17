using System;

namespace TreeCalculator
{
    public static class ParseString
    {
        /// <summary>
        /// Ignore all spaces and returns pointer for the next non space character
        /// </summary>
        /// <param name="buffer"> given string </param>
        /// <param name="pointer"> сurrent string element pointer </param>
        /// <returns> pointer for the next non space character </returns>
        static private int IgnoreSpaces(string buffer, int pointer)
        {
            while (buffer[pointer] == ' ' || buffer[pointer] == '\t')
            {
                pointer++;
            }
            return pointer;
        }

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
                int stringPointer = 1;
                stringPointer = IgnoreSpaces(expression, stringPointer);
                result[0] += expression[stringPointer];
                int bracketsCounter = 0;
                stringPointer = IgnoreSpaces(expression, stringPointer + 1);

                while (bracketsCounter != 0 || expression[stringPointer] != ' ')
                {
                    if (expression[stringPointer] == '(')
                    {
                        bracketsCounter++;
                    }
                    else if (expression[stringPointer] == ')')
                    {
                        bracketsCounter--;
                    }
                    result[1] += expression[stringPointer];
                    stringPointer++;
                }

                stringPointer = IgnoreSpaces(expression, stringPointer + 1);
                bracketsCounter = 0;

                while (bracketsCounter != 0 || expression[stringPointer] != ' ')
                {
                    if (expression[stringPointer] == '(')
                    {
                        bracketsCounter++;
                    }
                    else if (expression[stringPointer] == ')')
                    {
                        bracketsCounter--;
                    }
                    result[2] += expression[stringPointer];
                    stringPointer++;
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