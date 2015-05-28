using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    /// <summary>
    /// List class
    /// </summary>
    public class List<ElementType> : IEnumerable
    {
        /// <summary>
        /// Creates empty list
        /// </summary>
        public List()
        {
        }

        /// <summary>
        /// returns element key by its position
        /// </summary>
        /// <param name="position"> element position </param>
        /// <returns> element key </returns>
        public ElementType ElementKeyByPosition(int position)
        {
            if (numberOfElems <= position || position < 0)
            {
                throw new Exception("Smth is wrong");
            }
            int index = 0;
            var temp = this.head;
            while (index < position)
            {
                temp = temp.Next;
                index += 1;
            }
            return temp.Key;
        }

        /// <summary>
        /// Insert given key to the list
        /// </summary>
        /// <param name="key"> Inserted key </param>
        public void Insert(ElementType key)
        {
            var newElement = new ListElement(key);
            newElement.Next = this.head;
            if (this.head != null)
            {
                this.head.Prev = newElement;
            }
            this.head = newElement;
            this.numberOfElems++;
        }

        /// <summary>
        /// Deletes element by its key
        /// </summary>
        /// <param name="key"> Deleted key </param>
        public void Delete(ElementType key)
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

        /// <summary>
        /// Searches the element by its key
        /// </summary>
        /// <param name="key">  key for search </param>
        /// <returns> 1 - contains, 0 - not contains </returns>
        public bool Search(ElementType key)
        {
            ListElement temp = this.head;
            while (temp != null && !temp.Key.Equals(key))
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
        private ListElement SearchListElement(ElementType key)
        {
            ListElement temp = this.head;
            while (temp != null && !temp.Key.Equals(key))
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
            public ListElement(ElementType key)
            {
                this.Key = key;
            }

            public ElementType Key { get; set; }
            public ListElement Next { get; set; }
            public ListElement Prev { get; set; }
        }

        private ListElement head = null;
        private int numberOfElems = 0;

        /// <summary>
        /// List enumerator
        /// </summary>
        public class ListEnumerator : IEnumerator
        {
            private int position = -1;
            private List<ElementType> list;
            private ListElement currentElement;

            public ListEnumerator(List<ElementType> list)
            {
                this.list = list;
                currentElement = null;
            }

            public object Current
            {
                get
                {
                    return currentElement.Key;
                }
            }

            public void Dispose()
            {
                this.list = null;
            }

            public bool MoveNext()
            {
                position++;
                if (currentElement == null)
                {
                    currentElement = list.head;
                }
                else
                {
                    currentElement = currentElement.Next;
                }
                return position < list.Size();
            }

            public void Reset()
            {
                position = -1;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }
        }

        /// <summary>
        /// IEnumerable inerface implementation
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListEnumerator(this) as IEnumerator;
        }
    }
}
