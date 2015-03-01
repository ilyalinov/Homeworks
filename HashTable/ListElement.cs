using System;

namespace HashTable
{
    class ListElement
    {
        public ListElement(string key)
        {
            this.key = key;
            this.next = null;
            this.prev = null;
        }

        public ListElement GetNext()
        {
            return this.next;
        }

        public ListElement GetPrev()
        {
            return this.prev;
        }

        public void SetNext(ListElement listElement)
        {
            this.next = listElement;
        }

        public void SetPrev(ListElement listElement)
        {
            this.prev = listElement;
        }

        public string GetKey()
        {
            return this.key;
        }

        private string key;
        private ListElement next;
        private ListElement prev;
    }
}
