using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilter
{
    /// <summary>
    /// List class
    /// </summary>
    public class List
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
        public void Insert(int key)
        {
            var newElement = new ListElement(key);
            newElement.Next = this.Head;
            if (this.Head != null)
            {
                this.Head.Prev = newElement;
            }
            this.Head = newElement;
            this.numberOfElems++;
        }

        /// <summary>
        /// Deletes element by its key
        /// </summary>
        /// <param name="key"> Deleted key </param>
        public void Delete(int key)
        {
            var listElement = this.SearchListElement(key);
            if (listElement != null)
            {
                Console.WriteLine("Deleted element with key: " + listElement.Key);
                if (listElement.Prev == null)
                {
                    this.Head = listElement.Next;
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

        /// <summary>
        /// Searches the element by its key
        /// </summary>
        /// <param name="key">  key for search </param>
        /// <returns> 1 - contains, 0 - not contains </returns>
        public bool Search(int key)
        {
            ListElement temp = this.Head;
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
        private ListElement SearchListElement(int key)
        {
            ListElement temp = this.Head;
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
            ListElement temp = this.Head;
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
        public class ListElement 
        {
            public ListElement(int key)
            {
                this.Key = key;
            }

            public int Key { get; set; }
            public ListElement Next { get; set; }
            public ListElement Prev { get; set; }
        }

        private ListElement Head = null;

        /// <summary>
        /// Get head property
        /// </summary>
        public ListElement GetHead
        {
            get
            {
                return this.Head;
            }
        }

        private int numberOfElems = 0;
    }
}
