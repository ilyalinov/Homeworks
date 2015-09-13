using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    /// <summary>
    /// Class for array-based stack
    /// </summary>
    class ArrayStack : AbstractStack
    {
        private int[] array;
        private int size = 0;
        private const int maxSize = 1000;

        /// <summary>
        /// Constructs stack with constant size (1000)
        /// </summary>
        public ArrayStack()
        {
            this.array = new int[maxSize];
        }

        /// <summary>
        /// Pushes key to the stack
        /// </summary>
        /// <param name="key"> Pushed key </param>
        public void Push(int key)
        {
            this.array[size] = key;
            size++;
        }

        /// <summary>
        /// Checks stack on the emptiness
        /// </summary>
        /// <returns> 1 - empty, 0 - not empty </returns>
        public bool IsEmpty()
        {
            return (this.size == 0);
        }
        
        /// <summary>
        /// Deletes element from stack
        /// </summary>
        /// <returns> Deleted key </returns>
        public int Pop()
        {
            int result = 0;
            if (this.size == 0)
            {
                result = -1;
            }
            else
            {
                result = this.array[size - 1];
                size--;
            }
            return result;
        }
    }
}
