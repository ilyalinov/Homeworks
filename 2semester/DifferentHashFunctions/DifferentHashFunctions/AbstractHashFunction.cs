using System;

namespace DifferentHashFunctions
{
    public interface AbstractHashFunction
    {
        /// <summary>
        /// Get string's hash code
        /// </summary>
        /// <param name="expression"> given string </param>
        /// <param name="hashTableSize"> hash table size </param>
        /// <returns> hash code </returns>
        int HashCode(string expression, int hashTableSize);
    }
}
