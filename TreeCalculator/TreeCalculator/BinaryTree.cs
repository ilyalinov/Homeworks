using System;

namespace TreeCalculator
{
    /// <summary>
    /// Binary tree class
    /// </summary>
    public class BinaryTree
    {
        /// <summary>
        /// Tree element class
        /// </summary>
        private abstract class TreeElement
        {
            public TreeElement()
            {
            }

            /// <summary>
            /// Count subtree expression
            /// </summary>
            /// <returns></returns>
            public abstract int Count();

            /// <summary>
            /// Print subtree in the postfix notation
            /// </summary>
            public abstract void Print();
        }

        /// <summary>
        /// Operation class
        /// </summary>
        private abstract class Operation : TreeElement
        {
            public TreeElement Right { get; set; }
            public TreeElement Left { get; set; }

            public Operation()
            {
            }

            //public override int Count()
            //{
            //    switch (this.Key)
            //    {
            //        case "+":
            //            return this.Left.Count() + this.Right.Count();
            //        case "-":
            //            return this.Left.Count() - this.Right.Count();
            //        case "*":
            //            return this.Left.Count() * this.Right.Count();
            //        case "/":
            //            return this.Left.Count() / this.Right.Count();
            //        default:
            //            throw new Exception("Something is very wrong");
            //    }
            //}
        }

        private class Plus : Operation
        {
            public Plus() : base()
            {
            }

            public override int Count()
            {
                return this.Left.Count() + this.Right.Count(); 
            }

            public override void Print()
            {
                this.Left.Print();
                this.Right.Print();
                Console.WriteLine("+ ");
            }
        }

        private class Minus : Operation
        {
            public Minus() : base()
            {
            }

            public override int Count()
            {
                return this.Left.Count() - this.Right.Count();
            }

            public override void Print()
            {
                this.Left.Print();
                this.Right.Print();
                Console.WriteLine("- ");
            }
        }

        private class Multiplication : Operation
        {
            public Multiplication(): base()
            {
            }

            public override int Count()
            {
                return this.Left.Count() * this.Right.Count();
            }

            public override void Print()
            {
                this.Left.Print();
                this.Right.Print();
                Console.WriteLine("* ");
            }
        }

        private class Division : Operation
        {
            public Division() : base()
            {
            }

            public override int Count()
            {
                return this.Left.Count() / this.Right.Count();
            }

            public override void Print()
            {
                this.Left.Print();
                this.Right.Print();
                Console.WriteLine("/ ");
            }
        }

        /// <summary>
        /// Operand class
        /// </summary>
        private class Operand : TreeElement
        {
            public string Key { get; set; }

            public Operand(string key)
            {
                this.Key = key;
            }

            public override void Print()
            {
                Console.WriteLine("{0} ", this.Key);
            }

            public override int Count()
            {
                return Convert.ToInt32(this.Key);
            }
        }

        private TreeElement head = null;

        /// <summary>
        /// Create null binary tree
        /// </summary>
        public BinaryTree()
        {
        }

        /// <summary>
        /// Create binary tree by given expression
        /// </summary>
        /// <param name="expression"> given arithmetic expression </param>
        public BinaryTree(string expression)
        {
            this.head = new Multiplication();
            this.CreateTree(expression, this.head);
        }

        /// <summary>
        /// Write operation in the given tree element and the operands in the children
        /// </summary>
        /// <param name="treeElement"> given tree element </param>
        private void CreateTree(string expression, TreeElement treeElement)
        {
            if (ParseString.IsOperandComplex(expression))
            {
                string[] dividedExpression = ParseString.DivideOperand(expression);
                switch (dividedExpression[0])
                {
                    case "+":
                        treeElement = new Plus();
                        break;
                    case "-":
                        treeElement = new Minus();
                        break;
                    case "*":
                        treeElement = new Multiplication();
                        break;
                    case "/":
                        treeElement = new Division();
                        break;
                    default:
                        throw new Exception("Something is very wrong");
                }
                var temp = treeElement as Operation;
                this.CreateTree(dividedExpression[1], temp.Left);
                this.CreateTree(dividedExpression[2], temp.Right);
            }
            else
            {
                treeElement = new Operand(expression);
            }


            //string[] dividedExpression = ParseString.DivideOperand(treeElement.Key);
            //treeElement.Key = dividedExpression[0];
            //if (ParseString.IsOperandComplex(dividedExpression[1]))
            //{
            //    treeElement.Left = new Operation(dividedExpression[1]);
            //    this.CreateTree(treeElement.Left);
            //}
            //else
            //{
            //    treeElement.Left = new Operand(dividedExpression[1]);
            //}
            //if (ParseString.IsOperandComplex(dividedExpression[2]))
            //{
            //    treeElement.Right = new Operation(dividedExpression[2]);
            //    this.CreateTree(treeElement.Right);
            //}
            //else
            //{
            //    treeElement.Right = new Operand(dividedExpression[2]);
            //}
        }

        /// <summary>
        /// Count tree value
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return this.head.Count();
        }

        /// <summary>
        /// Print binary tree to console in the postfix notation
        /// </summary>
        public void PrintTree()
        {
            Console.WriteLine("Printed tree in the postfix notation: ");
            this.head.Print();
        }
    }
}