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
    public class Set<T> : IEnumerable
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
        public bool DoesContain(T key)
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

        /// <summary>
        /// Add element to the list
        /// </summary>
        /// <param name="key"></param>
        public void AddElement(T key)
        {
            if (DoesContain(key))
            {
                throw new AddExistingElementException("Such element already exists in your set");
            }
            this.list.Add(key);
        }

        /// <summary>
        /// Delete element by its key
        /// </summary>
        /// <param name="key"> given element key </param>
        public void DeleteElement(T key)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (list[i].Equals(key))
                {
                    list.RemoveAt(i);
                }
            }
        }

        /// <summary>
        /// Find 2 sets crossing
        /// </summary>
        /// <param name="set"></param>
        /// <param name="set2"></param>
        /// <returns> crossing set </returns>
        public Set<T> Crossing(Set<T> set)
        {
            Set<T> crossingSet = new Set<T>(); 
            foreach (var item1 in set.list)
            {
                foreach (var item2 in this.list)
                {
                    if (item1.Equals(item2))
                    {
                        crossingSet.list.Add(item1);
                    }
                }
            }
            return crossingSet;
        }

        /// <summary>
        /// Find 2 sets association
        /// </summary>
        /// <param name="set1"></param>
        /// <param name="set2"></param>
        /// <returns> Association set </returns>
        public Set<T> Association(Set<T> set)
        {
            Set<T> associationSet = new Set<T>();
            foreach (var item in set.list)
            {
                associationSet.list.Add(item);
            }
            foreach (var item in this.list)
            {
                if (set.DoesContain(item))
                {
                    continue;
                }
                associationSet.AddElement(item);
            }
            return associationSet;
        }

        /// <summary>
        /// Get default list enumerator
        /// </summary>
        /// <returns></returns>
        public IEnumerator GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
