using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    /// <summary>
    /// Class for reference-based stack
    /// </summary>
    class ReferenceStack : AbstractStack
    {
        /// <summary>
        /// Stack element
        /// </summary>
        private class StackElement
        {
            /// <summary>
            /// Constructs stack element by the given key
            /// </summary>
            /// <param name="number"> stack element key </param>
            public StackElement(int number)
            {
                this.Key = number;
            }

            /// <summary>
            /// Get + set next stack element
            /// </summary>
            public StackElement Next
            {
                get
                {
                    return (m_Next);
                }
                set
                {
                    m_Next = value;
                }
            }

            /// <summary>
            /// Get + set stack element key
            /// </summary>
            public int Key { get; set; }

            private StackElement m_Next = null;
        }

        private StackElement head = null;
        private int size = 0;

        /// <summary>
        /// Constructs null stack
        /// </summary>
        public ReferenceStack()
        {
        }

        /// <summary>
        /// Pushes key to the stack
        /// </summary>
        /// <param name="key"> Added key </param>
        public void Push(int key)
        {
            var newElement = new StackElement(key);
            var temp = this.head;
            this.head = newElement;
            this.head.Next = temp;
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
        /// Deletes stack element
        /// </summary>
        /// <returns> Deleted key </returns>
        public int Pop()
        {
            int result = 0;
            try
            {
                result = this.head.Key;
                this.head = this.head.Next;
                this.size--;
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Caught null reference exception, stack is empty");
                result = -1;
            }
            return result;
        }
    }
}
