using System;

namespace HashTable
{
    /// <summary>
    /// List class
    /// </summary>
    class List
    {
        /// <summary>
        /// Creates empty list
        /// </summary>
        public List()
        {
        }

        /// <summary>
        /// Inserts given key to the list
        /// </summary>
        /// <param name="key"> Inserted key </param>
        public void Insert(string key)
        {
            var newElement = new ListElement(key);
            newElement.Next = this.head;
            if (this.head != null)
            {
                this.head.Prev = newElement;
            }
            this.head = newElement;
            this.numberOfElems++;
            Console.WriteLine("Element inserted");
        }

        /// <summary>
        /// Deletes element by its key
        /// </summary>
        /// <param name="key"> Deleted key </param>
        public void Delete(string key)
        {
            var listElement = this.SearchListElement(key);
            if (listElement != null)
            {
                Console.WriteLine("Deleted element with key: " + listElement.Key);
                if (listElement.Prev == null)
                {
                    this.head = listElement.Next;
                }
                else
                {
                    listElement.Prev.Next = listElement.Next;
                }
                if (listElement.Next != null)
                {
                    listElement.Next.Prev = listElement.Prev;
                }
                this.numberOfElems--;
            }
            else
            {
                Console.WriteLine("Such element doesn't exist");
            }
        }

        /// <summary>
        /// Checks list on emptiness
        /// </summary>
        /// <returns> 1 - list is empty; 0 - not empty </returns>
        public bool IsEmpty()
        {
            return (this.numberOfElems == 0);
        }

        // Searches the element by its key
        public bool Search(string key)
        {
            ListElement temp = this.head;
            while (temp != null && temp.Key != key)
            {
                temp = temp.Next;
            }
            return (temp != null);
        }

        /// <summary>
        /// Searches list element and returns it
        /// </summary>
        /// <param name="key"> Key for search </param>
        /// <returns></returns>
        private ListElement SearchListElement(string key)
        {
            ListElement temp = this.head;
            while (temp != null && temp.Key != key)
            {
                temp = temp.Next;
            }
            return temp;
        }

        /// <summary>
        /// Prints whole list to console
        /// </summary>
        public void Print()
        {
            if (this.IsEmpty())
            {
                Console.WriteLine("Your list is empty");
                return;
            }
            ListElement temp = this.head;
            Console.WriteLine("Your list: ");
            while (temp != null)
            {
                Console.Write("{0} ", temp.Key);
                temp = temp.Next;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// List size
        /// </summary>
        /// <returns> Number of elements </returns>
        public int Size()
        {
            return this.numberOfElems;
        }

        /// <summary>
        /// List elements class
        /// </summary>
        private class ListElement
        {
            public ListElement(string key)
            {
                this.m_Key = key;
            }

            /// <summary>
            /// Get + set next element
            /// </summary>
            public ListElement Next
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
            /// Get + set previous element
            /// </summary>
            public ListElement Prev
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
            public string Key
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

            private string m_Key;
            private ListElement m_Next;
            private ListElement m_Prev;
        }

        private ListElement head = null;
        private int numberOfElems = 0;
    }
}
