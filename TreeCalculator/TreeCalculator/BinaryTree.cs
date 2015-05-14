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
            public string Key { get; set; }
            public TreeElement Right { get; set; }
            public TreeElement Left { get; set; }


            /// <summary>
            /// Construct tree element by its key
            /// </summary>
            /// <param name="key"></param>
            public TreeElement(string key)
            {
                this.Key = key;
            }

            /// <summary>
            /// Count subtree expression
            /// </summary>
            /// <returns></returns>
            public abstract int Count();

            /// <summary>
            /// Print subtree in the postfix notation
            /// </summary>
            public void Print()
            {
                if (this.Left != null)
                {
                    this.Left.Print();
                }
                if (this.Right != null)
                {
                    this.Right.Print();
                }
                Console.Write(Key + " ");
            }
        }

        /// <summary>
        /// Operation class
        /// </summary>
        private class Operation : TreeElement
        {
            public Operation(string key) : base(key)
            {
            }

            public override int Count()
            {
                switch (this.Key)
                {
                    case "+":
                        return this.Left.Count() + this.Right.Count();
                    case "-":
                        return this.Left.Count() - this.Right.Count();
                    case "*":
                        return this.Left.Count() * this.Right.Count();
                    case "/":
                        return this.Left.Count() / this.Right.Count();
                    default:
                        throw new Exception("Something is very wrong");
                }
            }
        }

        /// <summary>
        /// Operand class
        /// </summary>
        private class Operand : TreeElement
        {
            public Operand(string key)
                : base(key)
            {
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
            this.head = new Operation(expression);
            this.CreateTree(this.head);
        }

        /// <summary>
        /// Write operation in the given tree element and the operands in the children
        /// </summary>
        /// <param name="treeElement"> given tree element </param>
        private void CreateTree(TreeElement treeElement)
        {
            string[] dividedExpression = ParseString.DivideOperand(treeElement.Key);
            treeElement.Key = dividedExpression[0];
            if (ParseString.IsOperandComplex(dividedExpression[1]))
            {
                treeElement.Left = new Operation(dividedExpression[1]);
                this.CreateTree(treeElement.Left);
            }
            else
            {
                treeElement.Left = new Operand(dividedExpression[1]);
            }
            if (ParseString.IsOperandComplex(dividedExpression[2]))
            {
                treeElement.Right = new Operation(dividedExpression[2]);
                this.CreateTree(treeElement.Right);
            }
            else
            {
                treeElement.Right = new Operand(dividedExpression[2]);
            }
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