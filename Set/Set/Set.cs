using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetNamespace
{
    /// <summary>
    /// Abstract data type set
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Set<T> : IEnumerable
    {
        private List<T> list = new List<T>();

        /// <summary>
        /// Create null set
        /// </summary>
        public Set()
        {
        }

        /// <summary>
        /// Does set contain such element key?  
        /// </summary>
        /// <param name="key"> element key </param>
        /// <returns></returns>
        public bool IsContains(T key)
        {
            foreach (var item in list)
            {
                if (item.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public void AddElement(T key)
        {
            if (IsContains(key))
            {
                throw new MyException("Such element already exists in your set");
            }
            this.list.Add(key);
        }

        public Set<T> Crossing(Set<T> set1, Set<T> set2)
        {
            Set<T> crossingSet = new Set<T>(); 
            foreach (var item1 in set1.list)
            {
                foreach (var item2 in set2.list)
                {
                    if (item1.Equals(item2))
                    {
                        crossingSet.list.Add(item1);
                    }
                }
            }
            return crossingSet;
        }

        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
