using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculatorNamespace
{
    class ArrayStack : AbstractStack
    {
        private int[] array;
        private int size = 0;
        private const int maxSize = 1000;

        public ArrayStack()
        {
            this.array = new int[maxSize];
        }

        public void Push(int key)
        {
            this.array[size] = key;
            size++;
        }

        public bool IsEmpty()
        {
            return (this.size == 0);
        }
        
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
