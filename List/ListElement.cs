using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListElement
    {
        public ListElement(int key)
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

        public int GetKey()
        {
            return this.key;
        }

        private int key;
        private ListElement next;
        private ListElement prev;
    }
}
