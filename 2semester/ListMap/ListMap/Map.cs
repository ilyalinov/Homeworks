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
        /// Function changes every list element key
        /// </summary>
        /// <param name="list"> given list </param>
        /// <param name="modifier"> given modifying function </param>
        /// <returns></returns>
        public static List Map(List list, Func<int, int> modifier)
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
