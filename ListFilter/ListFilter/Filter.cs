using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFilter
{
    public static class FilterClass
    {
        /// <summary>
        /// Function that change somehow given key
        /// </summary>
        /// <param name="key"> modified key </param>
        /// <returns></returns>
        public static bool ListElementFilter(int key)
        {
            return (key % 2) == 0;
        }

        /// <summary>
        /// delegate for list element filter
        /// </summary>
        /// <param name="key"> given key </param>
        /// <returns> filter result </returns>
        public delegate bool Modifier(int key);

        /// <summary>
        /// Function filters every list element
        /// </summary>
        /// <param name="list"> list </param>
        /// <param name="modifier"> filter function </param>
        /// <returns> Filtered list </returns>
        public static List Filter(List list, Modifier modifier)
        {
            var newList = new List();
            var temp = list.GetHead;
            while (temp != null)
            {
                if (modifier(temp.Key))
                {
                    newList.Insert(temp.Key);
                }
                temp = temp.Next;
            }
            return newList;
        }
    }
}
