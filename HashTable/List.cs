using System;

namespace HashTable
{
    class List
    {
        // Creates empty list
        public List()
        {
            this.head = null;
            this.numberOfElems = 0;
        }

        // Inserts given key to the list
        public void Insert(ListElement newElement)
        {
            newElement.SetNext(this.head);
            if (this.head != null)
            {
                this.head.SetPrev(newElement);
            }
            this.head = newElement;
            this.numberOfElems++;
        }

        // Deletes list element from the list
        public string Delete(ListElement listElement)
        {
            string key = listElement.GetKey();
            if (listElement.GetPrev() == null)
            {
                this.head = listElement.GetNext();
            }
            else
            {
                listElement.GetPrev().SetNext(listElement.GetNext());
            }
            if (listElement.GetNext() != null)
            {
                listElement.GetNext().SetPrev(listElement.GetPrev());
            }
            this.numberOfElems--;
            return key;
        }

        // Checks list on emptiness
        public bool IsEmpty()
        {
            return (this.numberOfElems == 0);
        }

        // Searches the element by its key
        public ListElement Search(string key)
        {
            ListElement temp = this.head;
            while (temp != null && temp.GetKey() != key)
            {
                temp = temp.GetNext();
            }
            if (temp == null)
            {
                Console.WriteLine("Element doesn't exist");
            }
            else
            {
                Console.WriteLine("Found element with key: {0}", temp.GetKey());
            }
            return temp;
        }

        // Prints whole list to console
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
                Console.Write("{0} ", temp.GetKey());
                temp = temp.GetNext();
            }
            Console.WriteLine();
        }

        // Returns list size
        public int Size()
        {
            return this.numberOfElems;
        }
        
        private ListElement head;
        private int numberOfElems;
    }
}
