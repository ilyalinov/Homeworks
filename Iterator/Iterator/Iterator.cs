using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorNamespace
{
    public class IteratorClass : IIterator
    {
        /// <summary>
        /// Constructs new iterator
        /// </summary>
        /// <param name="tree"> given bunary tree </param>
        public IteratorClass(BinaryTree tree)
        {
            this.i = 0;
            this.Current = tree.Head();
            this.nodeList.Add(this.Current);
        }

        /// <summary>
        /// List of iterated nodes
        /// </summary>
        private List<TreeElement> nodeList;

        private int i = 0;

        /// <summary>
        /// Current iterator element
        /// </summary>
        public TreeElement Current { get; set; }

        public TreeElement Next()
        {
            TreeElement temp = this.Current;
            if (i >= nodeList.Count)
            {
                this.Current = null;
            }
            else
            {
                this.Current = nodeList[i];
                i++;
            }
            if (temp.Left != null)
            {
                nodeList.Add(temp.Left);
            }
            if (temp.Right != null)
            {
                nodeList.Add(temp.Right);
            }
            return temp;
        }

        /// <summary>
        /// Is end?
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return (this.Current == null);
        }

        /// <summary>
        /// Reset iterator
        /// </summary>
        /// <param name="tree"> given binary tree </param>
        /// <returns> new iterator </returns>
        public IteratorClass Reset(BinaryTree tree)
        {
            this.nodeList = null;
            this.i = 0;
            this.Current = tree.Head();
            return this;
        }
    }
}
