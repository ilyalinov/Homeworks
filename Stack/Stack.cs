using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    // Class for stack data structure
    class Stack
    {
        private StackElement head;
        private int numberOfElems;

        // Creates empty stack
        public Stack()
        {
            this.numberOfElems = 0;
            this.head = null;
        }

        // Pushes 1 integer number to stack
        public void Push(int key)
        {
            StackElement newElement = new StackElement(key);
            StackElement temp = this.head;
            this.head = newElement;
            this.head.SetNext(temp);
            numberOfElems++;
        }

        // Checks stack on emptiness
        public bool IsEmpty()
        {
            return (this.numberOfElems == 0);
        }

        // Deletes stack element and returns its value
        public void Pop()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Stack is empty");
            }
            else
            {
                Console.WriteLine("Deleted element with key: {0}", this.head.GetKey());
                this.head = this.head.GetNext();
                numberOfElems--;
            }
        }

        // Returns elements quantity int the stack
        public int GetElemsQuantity()
        {
            return this.numberOfElems;
        }
    }
}
