using System;

namespace TreeCalculator
{
    class BinaryTree
    {
        private abstract class TreeElement
        {
            protected string m_Key = null;
            protected TreeElement right = null;
            protected TreeElement left = null;

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

            public TreeElement(string key)
            {
                this.m_Key = key;
            }

            public abstract int Count();

            public void Print()
            {
                Console.Write(m_Key);
            }
        }

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
        /// Creates null binary tree
        /// </summary>
        public BinaryTree()
        {
        }

        public BinaryTree(string expression)
        {
            this.head = new Operation(expression);
            this.Method(this.head);
        }

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

        public int Count()
        {
            return this.head.Count();
        }
    }
}