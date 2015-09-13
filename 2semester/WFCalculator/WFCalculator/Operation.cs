using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFCalculator
{
    /// <summary>
    /// Abstract operation
    /// </summary>
    abstract class Operation
    {
        public Operation()
        {
        }

        public abstract int Count(int operand1, int operand2);
    }

    /// <summary>
    /// Division class
    /// </summary>
    class Division : Operation
    {
        public Division() : base()
        {
        }

        public override int Count(int operand1, int operand2)
        {
            if (operand2 == 0)
            {
                throw new NullReferenceException("Division by zero!!!");
            }
            return operand1 / operand2;
        }
    }

    /// <summary>
    /// Plus class
    /// </summary>
    class Plus : Operation
    {
        public Plus() : base()
        {
        }

        public override int Count(int operand1, int operand2)
        {
            return operand1 + operand2;
        }
    }

    /// <summary>
    /// Minus class
    /// </summary>
    class Minus : Operation
    {
        public Minus() : base()
        {
        }

        public override int Count(int operand1, int operand2)
        {
            return operand1 - operand2;
        }
    }

    /// <summary>
    /// Multiplication class
    /// </summary>
    class Multiplication : Operation
    {
        public Multiplication() : base()
        {
        }

        public override int Count(int operand1, int operand2)
        {
            return operand1 * operand2;
        }
    }
}
