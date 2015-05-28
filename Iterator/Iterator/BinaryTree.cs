using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorNamespace
{
    public class BinaryTree
    {
        private TreeElement head = null;

        /// <summary>
        /// Get head
        /// </summary>
        /// <returns> tree head </returns>
        public TreeElement Head()
        {
            return this.head;
        }

        /// <summary>
        /// Create null binary tree
        /// </summary>
        public BinaryTree()
        {
        }

        public BinaryTree(List<int> list)
        {
            list.Sort();
            var temp = this.head;
            for (int i = 0; i < list.Count; i++)
            {
                temp = new TreeElement(list[i]);
                if (i < list.Count - 1)
                {
                    if (list[i] < list[i + 1])
                    {
                        temp = temp.Left;
                    }
                    else
                    {
                        temp = temp.Right;
                    }
                }
            }
        }

        //public void DeleteNode(TreeElement element)
        //{
            
        //}
    }
}
