using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    // Class for stack elements
    class StackElement
    {
        // Constructs object with given key
        public StackElement (int key)
        {
            this.key = key;
            this.next = null;
        }

        // Constructs object without any key
        public StackElement() : this(0)
        {
        }

        // Sets given stack element as a next to the primary one
        public void SetNext(StackElement stackElement)
        {
            this.next = stackElement;
        }

        // Returns the stack element key
        public int GetKey()
        {
            return this.key;
        }

        // Returns next stack element
        public StackElement GetNext()
        {
            return this.next;
        }

        private int key;
        private StackElement next;
    }
}
