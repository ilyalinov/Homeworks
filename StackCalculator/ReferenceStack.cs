using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    class ReferenceStack : AbstractStack
    {
        private class StackElement
        {
            public StackElement(int number)
            {
                this.m_Key = number;
            }

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

            public int Key
            {
                get
                {
                    return (m_Key);
                }
                set
                {
                    m_Key = value;
                }
            }

            private int m_Key = 0;
            private StackElement m_Next = null;
        }

        private StackElement head = null;
        private int size = 0;

        public ReferenceStack()
        {
        }

        public void Push(int key)
        {
            var newElement = new StackElement(key);
            var temp = this.head;
            this.head = newElement;
            this.head.Next = temp;
            size++;
        }

        public bool IsEmpty()
        {
            return (this.size == 0);
        }

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
