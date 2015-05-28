using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    // Class for stack data structure
    class Stack<T>
    {
        private StackElement head;
        private int numberOfElems;

        private class StackElement
        {
            public StackElement(T key)
            {
                this.Key = key;
                this.Next = null;
            }

            public T Key { get; set; }
            public StackElement Next { get; set; }
        }

        /// <summary>
        /// Create empty stack
        /// </summary>
        public Stack()
        {
            this.numberOfElems = 0;
            this.head = null;
        }

        /// <summary>
        /// Push element to the stack
        /// </summary>
        /// <param name="key"> given element key </param>
        public void Push(T key)
        {
            var newElement = new StackElement(key);
            var temp = this.head;
            this.head = newElement;
            this.head.Next = temp;
            numberOfElems++;
        }

        /// <summary>
        /// Delete element from the stack
        /// </summary>
        public void Pop()
        {
            if (this.IsEmpty())
            {
                throw new Exception("Stack is empty");
            }
            else
            {
                Console.WriteLine("Deleted element with key: {0}", this.head.Key);
                this.head = this.head.Next;
                numberOfElems--;
            }
        }

        /// <summary>
        /// Stack size
        /// </summary>
        /// <returns> number of stack elements </returns>
        public int GetElemsQuantity()
        {
            return this.numberOfElems;
        }

        /// <summary>
        /// Is stack empty?
        /// </summary>
        /// <returns> 1 - stack is empty, 0 - stack isn't emmpty </returns>
        public bool IsEmpty()
        {
            return (this.head == null);
        }
    }
}
