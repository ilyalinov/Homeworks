using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListMap
{
    public static class MapClass
    {
        /// <summary>
        /// Function that change somehow given key
        /// </summary>
        /// <param name="key"> modified key </param>
        /// <returns></returns>
        public static int ListElementModifier(int key)
        {
            return key * key;
        }

        /// <summary>
        /// delegate for list element modifier
        /// </summary>
        /// <param name="key"> given key </param>
        /// <returns> changed key </returns>
        public delegate int Modifier(int key);

        /// <summary>
        /// Function changes every list element key
        /// </summary>
        /// <param name="list"> given list </param>
        /// <param name="modifier"> given modifying function </param>
        /// <returns></returns>
        public static List Map(List list, Modifier modifier)
        {
            var temp = list.GetHead;
            while (temp != null)
            {
                temp.Key = modifier(temp.Key);
                temp = temp.Next;
            }
            return list;
        }
    }
}
