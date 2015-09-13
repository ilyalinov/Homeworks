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
        /// Function filters every list element
        /// </summary>
        /// <param name="list"> list </param>
        /// <param name="modifier"> filter function </param>
        /// <returns> Filtered list </returns>
        public static List Filter(List list, Func<int, bool> modifier)
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
