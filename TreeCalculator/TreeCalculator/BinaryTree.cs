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
            protected string m_Key = null;
            protected TreeElement right = null;
            protected TreeElement left = null;

            /// <summary>
            /// Get and set tree element key
            /// </summary>
            public string Key
            {
                get
                {
                    return this.m_Key;
                }
                set
                {
                    this.m_Key = value;
                }
            }

            /// <summary>
            /// get and set right child
            /// </summary>
            public TreeElement Right
            {
                get 
                {
                    return this.right;
                }
                set
                {
                    this.right = value;
                }
            }

            /// <summary>
            /// Get and set left child
            /// </summary>
            public TreeElement Left
            {
                get
                {
                    return this.left;
                }
                set
                {
                    this.left = value;
                }
            }

            /// <summary>
            /// Construct tree element by its key
            /// </summary>
            /// <param name="key"></param>
            public TreeElement(string key)
            {
                this.m_Key = key;
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
                Console.Write(m_Key + " ");
            }
        }

        /// <summary>
        /// Operation class
        /// </summary>
        private class Operation : TreeElement
        {
            public Operation(string key)
                : base(key)
            {
            }

            public override int Count()
            {
                switch (this.m_Key)
                {
                    case "+":
                        return this.left.Count() + this.right.Count();
                    case "-":
                        return this.left.Count() - this.right.Count();
                    case "*":
                        return this.left.Count() * this.right.Count();
                    case "/":
                        return this.left.Count() / this.right.Count();
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
                return Convert.ToInt32(this.m_Key);
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
            this.Method(this.head);
        }

        /// <summary>
        /// Write operation in the given tree element and the operands in the children
        /// </summary>
        /// <param name="treeElement"> given tree element </param>
        private void Method(TreeElement treeElement)
        {
            string[] dividedExpression = ParseString.DivideOperand(treeElement.Key);
            treeElement.Key = dividedExpression[0];
            if (ParseString.IsOperandComplex(dividedExpression[1]))
            {
                treeElement.Left = new Operation(dividedExpression[1]);
                this.Method(treeElement.Left);
            }
            else
            {
                treeElement.Left = new Operand(dividedExpression[1]);
            }
            if (ParseString.IsOperandComplex(dividedExpression[2]))
            {
                treeElement.Right = new Operation(dividedExpression[2]);
                this.Method(treeElement.Right);
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