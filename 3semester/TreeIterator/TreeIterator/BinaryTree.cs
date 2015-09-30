using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeIterator
{
    /// <summary>
    /// Binary tree class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable
    {
        /// <summary>
        /// Tree element class
        /// </summary>
        private class TreeElement
        {
            public T value { get; set; }
            public TreeElement left { get; set; }
            public TreeElement right { get; set; }
            public TreeElement parent { get; set; }

            public TreeElement(T value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
                this.parent = null;
            }
        }

        /// <summary>
        /// Tree head
        /// </summary>
        private TreeElement head;

        /// <summary>
        /// Create null binary tree
        /// </summary>
        public BinaryTree()
        {
        }

        /// <summary>
        /// Checks tree on the emptiness
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return this.head == null;
        }

        /// <summary>
        /// Add an element to the tree
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (this.head == null)
            {
                this.head = new TreeElement(value);
                return;
            }

            TreeElement temp = this.head;
            TreeElement parent = null;
            while (temp != null)
            {
                parent = temp;
                if (value.CompareTo(temp.value) > 0)
                {
                    temp = temp.right;
                }
                else
                {
                    temp = temp.left;
                }
            }
            TreeElement newElement = new TreeElement(value);
            if (value.CompareTo(parent.value) > 0)
            {
                parent.right = newElement;
            }
            else
            {
                parent.left = newElement;
            }
            newElement.parent = parent;
        }

        /// <summary>
        /// Search an element in tree
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool Search(T value)
        {
            return (ElementSearch(value) != null);
        }

        private TreeElement ElementSearch(T value)
        {
            TreeElement temp = this.head;
            while (temp != null)
            {
                if (value.CompareTo(temp.value) == 0)
                {
                    return temp;
                }
                else if (value.CompareTo(temp.value) > 0)
                {
                    temp = temp.right;
                }
                else if (value.CompareTo(temp.value) < 0)
                {
                    temp = temp.left;
                }
            }
            return temp;
        }

        private TreeElement TreeSuccessor(TreeElement treeElement)
        {
            TreeElement temp = treeElement.right;
            while (temp.left != null)
            {
                temp = temp.left;
            }
            return temp;
        }

        /// <summary>
        /// Remove an element from the tree
        /// </summary>
        /// <param name="value"></param>
        public void Remove(T value)
        {
            TreeElement treeElement = ElementSearch(value);
            TreeElement deletedElement = treeElement;
            TreeElement deletedElementChild = null;
            if (treeElement == null)
            {
                return;
            }
            if (treeElement.left == null || treeElement.right == null)
            {
                deletedElement = treeElement;
            }
            else
            {
                deletedElement = TreeSuccessor(treeElement);
            }
            if (deletedElement.left != null)
            {
                deletedElementChild = deletedElement.left;
            }
            else
            {
                deletedElementChild = deletedElement.right;
            }
            if (deletedElementChild != null)
            {
                deletedElementChild.parent = deletedElement.parent;
            }
            if (deletedElement.parent == null)
            {
                this.head = deletedElementChild;
            }
            else
            {
                if (deletedElement.parent.left == deletedElement)
                {
                    deletedElement.parent.left = deletedElementChild;
                }
                else
                {
                    deletedElement.parent.right = deletedElementChild;
                }
            }
            if (deletedElement != treeElement)
            {
                treeElement.value = deletedElement.value;
            }
        }

        /// <summary>
        /// Binary tree iterator class
        /// </summary>
        public class BinaryTreeIterator : IEnumerator<T>
        {
            private BinaryTree<T> binaryTree;
            private int index;
            private TreeElement currentElement = null;
            private List<TreeElement> list; 

            public BinaryTreeIterator (BinaryTree<T> binaryTree)
            {
                this.binaryTree = binaryTree;
                index = -1;
                list = new List<TreeElement>();
                list.Add(binaryTree.head);
                currentElement = null;
            }

            /// <summary>
            /// element being iterated
            /// </summary>
            public T Current
            {
                get { return currentElement.value; }
            }

            public void Dispose()
            {
            }
            
            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            /// <summary>
            /// Go to the next element
            /// </summary>
            /// <returns></returns>
            public bool MoveNext()
            {
                index++;
                if (list.Count <= index)
                {
                    return false;
                }
                else
                {
                    currentElement = list[index];
                    if (currentElement.left != null)
                    {
                        list.Add(currentElement.left);
                    }
                    if (currentElement.right != null)
                    {
                        list.Add(currentElement.right);
                    }
                    return true;
                }
            }

            /// <summary>
            /// Reset iterator
            /// </summary>
            public void Reset()
            {
                index = -1;
                currentElement = null;
                list = new List<TreeElement>();
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            return new BinaryTreeIterator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

