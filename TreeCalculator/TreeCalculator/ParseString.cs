using System;

namespace TreeCalculator
{
    static class ParseString
    {
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

        static public bool IsOperandComplex(string expression)
        {
            return (expression[0] == '(');
        }
    }
}