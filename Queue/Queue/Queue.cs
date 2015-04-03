using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueNamespace
{
    public class QueueClass
    {
        private class QueueElement
        {
            public QueueElement(int key, int priority)
            {
                this.m_Key = key;
                this.m_Priority = priority;
            }

            /// <summary>
            /// Get + set next element
            /// </summary>
            public QueueElement Next
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

            public int Priority
            {
                get 
                {
                    return m_Priority;
                }
                set 
                {
                    m_Priority = value;
                }
            }

            /// <summary>
            /// Get + set previous element
            /// </summary>
            public QueueElement Prev
            {
                get
                {
                    return (m_Prev);
                }
                set
                {
                    m_Prev = value;
                }
            }

            /// <summary>
            /// Get + set element key
            /// </summary>
            public int Key
            {
                get
                {
                    return m_Key;
                }
                set
                {
                    m_Key = value;
                }
            }

            private int m_Key = 0;
            private int m_Priority = 0;
            private QueueElement m_Next = null;
            private QueueElement m_Prev = null;
        }

        /// <summary>
        /// Create null queue
        /// </summary>
        public QueueClass()
        {
        }

        
        /// <summary>
        /// Add element to queue
        /// </summary>
        /// <param name="key"> inserted key </param>
        /// <param name="priority"> element priority </param>
        public void Enqueue(int key, int priority)
        {
            this.size++;
            var newElement = new QueueElement(key, priority);
            if (this.head == null)
            {
                this.head = newElement;
            }
            else
            {
                var temp = this.head;
                var temp1 = temp;
                while (temp != null && temp.Priority > newElement.Priority)
                {
                    temp1 = temp;
                    temp = temp.Next;
                }
                if (temp != null)
                {
                    if (temp.Prev != null)
                    {
                        newElement.Prev = temp.Prev;
                        temp.Prev.Next = newElement;
                        newElement.Next = temp;
                        temp.Prev = newElement;
                    }
                    else
                    {
                        newElement.Next = temp;
                        temp.Prev = newElement;
                        this.head = newElement;
                    }
                }
                else
                {
                    temp1.Next = newElement;
                    newElement.Prev = temp1;
                }
            }
        }

        public int Dequeue()
        {
            if (this.head == null)
            {
                throw new NullReferenceException("Your queue is empty");
            }
            else
            {
                int result = this.head.Key;
                this.head = this.head.Next;
                if (this.head != null)
                {
                    this.head.Prev = null;
                }
                this.size--;
                return result;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        private QueueElement head = null;
        private int size = 0;
    }
}
